using UnityEngine;
using UnityEngine.UI;
using System;
using UnityAds;
using Main;

namespace Goods
{
    public class RareBigGoodsForAdController : MonoBehaviour
    {
        int CompletedClickNumber;
        [SerializeField]
        int TimeInSecondsBetweenBigPrize;
        [SerializeField]
        int AdsForBigPrize;
        bool GiveThisPrize;
        [Header("PrizesNumber:")]
        [SerializeField]
        int MinCoinPrize;
        [SerializeField]
        int MaxCoinPrize;
        [SerializeField]
        int MinHeartsPrize;
        [SerializeField]
        int MaxHeartsPrize;
        [SerializeField]
        int MinEliteMoneyPrize;
        [SerializeField]
        int MaxEliteMoneyPrize;
        [Header("GameObjects:")]
        [SerializeField]
        GameObject OverlookAdProgress;
        [SerializeField]
        GameObject TimeProgress;
        [SerializeField]
        GameObject BigPrizeSystem;
        [SerializeField]
        GameObject TakingPrizesAnims;
        [SerializeField]
        GameObject FeedBox;
        [SerializeField]
        GameObject Clue;
        [SerializeField]
        GameObject CloseButton;
        [Header("Texts:")]
        [SerializeField]
        Text CurrentOverlookAdForBigPrize;
        [SerializeField]
        Text TimeBeforeOpenBigPrize;
        [SerializeField]
        Text CoinPrizeText;
        [SerializeField]
        Text HeartsPrizeText;
        [SerializeField]
        Text EliteMoneyPrizeText;
        [Header("Managers:")]
        [SerializeField]
        UnityAdsRewardedManager UnityAdsRewardedManager;
        [SerializeField]
        GameManager GameManager;
        int CoinPrize;
        int HeartsPrize;
        int EliteMoneyPrize;
        void Update()
        {
            if (((int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - PlayerPrefs.GetInt("LastGetBigPrizeForAdTime")) > TimeInSecondsBetweenBigPrize)
            {
                TimeProgress.SetActive(false);
                OverlookAdProgress.SetActive(true);
                if (PlayerPrefs.GetInt("OverlookAdForBigPrize") == 3)
                    OverlookAdProgress.SetActive(false);
            }
            else
            {
                TimeProgress.SetActive(true);
                OverlookAdProgress.SetActive(false);
                TimeBeforeOpenBigPrize.text = GameManager.SecondsNumberToClassicTime(TimeInSecondsBetweenBigPrize - ((int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - PlayerPrefs.GetInt("LastGetBigPrizeForAdTime")));
            }
        }
        void Start()
        {
            UnityAdsRewardedManager.UnityAdsShowComplete += WatchADS;
            CurrentOverlookAdForBigPrize.text = PlayerPrefs.GetInt("OverlookAdForBigPrize").ToString() + "/" + AdsForBigPrize.ToString();
        }
        
        void OnEnable() => UnityAdsRewardedManager.UnityAdsShowComplete += WatchADS;

        void OnDisable() => UnityAdsRewardedManager.UnityAdsShowComplete -= WatchADS;

        void OnDestroy() => UnityAdsRewardedManager.UnityAdsShowComplete -= WatchADS;

        public void ThisPrize() => GiveThisPrize = true;

        void WatchADS()
        {
            if (GiveThisPrize)
            {
                PlayerPrefs.SetInt("OverlookAdForBigPrize", PlayerPrefs.GetInt("OverlookAdForBigPrize") + 1);
                CurrentOverlookAdForBigPrize.text = PlayerPrefs.GetInt("OverlookAdForBigPrize").ToString() + "/" + AdsForBigPrize.ToString();
                GiveThisPrize = false;
            }
        }

        public void ClickToBigPrizeButton()
        {
            if (((int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - PlayerPrefs.GetInt("LastGetBigPrizeForAdTime")) > TimeInSecondsBetweenBigPrize)
            {
                if (PlayerPrefs.GetInt("OverlookAdForBigPrize") < AdsForBigPrize)
                {
                    UnityAdsRewardedManager.ShowAd();
                    ThisPrize();
                }
                else
                    OpenBigPrizeScreen();
            }
        }

        void OpenBigPrizeScreen()
        {
            PlayerPrefs.SetInt("LastGetBigPrizeForAdTime", (int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            PlayerPrefs.SetInt("OverlookAdForBigPrize", 0);
            FeedBox.transform.localScale = new Vector3(1, 1, 1);
            TakingPrizesAnims.SetActive(false);
            Clue.SetActive(true);
            BigPrizeSystem.SetActive(true);
        }

        public void ClickToFeedBox()
        {
            CompletedClickNumber++;
            if (CompletedClickNumber == 1)
                FeedBox.transform.localScale = new Vector3(0.85f, 0.85f, 1);
            else if (CompletedClickNumber == 2)
                FeedBox.transform.localScale = new Vector3(0.7f, 0.7f, 1);
            else if (CompletedClickNumber == 3)
            {
                TakingPrizesAnims.SetActive(true);
                Clue.SetActive(false);
                FeedBox.transform.localScale = new Vector3(0, 0, 1);

                CoinPrize = UnityEngine.Random.Range(MinCoinPrize, MaxCoinPrize + 1);
                HeartsPrize = UnityEngine.Random.Range(MinHeartsPrize, MaxHeartsPrize + 1);
                EliteMoneyPrize = UnityEngine.Random.Range(MinEliteMoneyPrize, MaxEliteMoneyPrize + 1);

                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + CoinPrize);
                PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") + HeartsPrize);
                PlayerPrefs.SetInt("EliteMoney", PlayerPrefs.GetInt("EliteMoney") + EliteMoneyPrize);

                CoinPrizeText.text = CoinPrize.ToString();
                HeartsPrizeText.text = HeartsPrize.ToString();
                EliteMoneyPrizeText.text = EliteMoneyPrize.ToString();

                CloseButton.SetActive(true);
            }
        }
    }
}
