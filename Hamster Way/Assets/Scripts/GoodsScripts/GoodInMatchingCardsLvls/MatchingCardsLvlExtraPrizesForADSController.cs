using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ScriptableObjects.LvlsManager;
using UnityAds;
using Finish.MatchingCardsLvlFinishSystem;

namespace Goods
{
    public class MatchingCardsLvlExtraPrizesForADSController : MonoBehaviour
    {
        [SerializeField]
        int Factor;
        [SerializeField]
        int MinFactor;
        [SerializeField]
        int MaxFactor;
        string ActionType = "up";
        [SerializeField]
        MatchingCardsLvlsManager LvlManager;
        int HeartsForAds;
        [SerializeField]
        Text HeartsForAdsText;
        [SerializeField]
        Text FactorText;
        bool GiveThisPrize;
        [SerializeField]
        GameObject ExtraPrizesWindow;
        [SerializeField]
        Text AllHeartsForLvlText;
        void Start()
        {
            StartCoroutine(ChangeFactor());
            UnityAdsRewardedManager.UnityAdsShowComplete += GetExtraPrizes;
        }

        void OnEnable() => UnityAdsRewardedManager.UnityAdsShowComplete += GetExtraPrizes;
        
        void OnDisable() => UnityAdsRewardedManager.UnityAdsShowComplete -= GetExtraPrizes;

        void OnDestroy() => UnityAdsRewardedManager.UnityAdsShowComplete -= GetExtraPrizes;

        public void ThisPrize() => GiveThisPrize = true;

        void GetExtraPrizes()
        {
            if (GiveThisPrize)
            {
                if (PlayerPrefs.GetInt("Stars") >= 1)
                {
                    HeartsForAds += Mathf.RoundToInt(LvlManager.HeartsForTheFirstHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * (Factor - 1) * PlayerPrefs.GetFloat("FactorForPrize"));
                    PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") + Mathf.RoundToInt(LvlManager.HeartsForTheFirstHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * (Factor - 1) * PlayerPrefs.GetFloat("FactorForPrize")));
                }
                if (PlayerPrefs.GetInt("Stars") >= 2)
                {
                    HeartsForAds += Mathf.RoundToInt(LvlManager.HeartsForTheSecondHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * (Factor - 1) * PlayerPrefs.GetFloat("FactorForPrize"));
                    PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") + Mathf.RoundToInt(LvlManager.HeartsForTheSecondHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * (Factor - 1) * PlayerPrefs.GetFloat("FactorForPrize")));
                }
                if (PlayerPrefs.GetInt("Stars") == 3)
                {
                    HeartsForAds += Mathf.RoundToInt(LvlManager.HeartsForTheThirdHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * (Factor - 1) * PlayerPrefs.GetFloat("FactorForPrize"));
                        PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") + Mathf.RoundToInt(LvlManager.HeartsForTheThirdHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * (Factor - 1) * PlayerPrefs.GetFloat("FactorForPrize")));
                }
                HeartsForAdsText.text = HeartsForAds.ToString();
                AllHeartsForLvlText.text = (HeartsForAds * Factor).ToString();
                ExtraPrizesWindow.SetActive(true);
                GiveThisPrize = false;
                Destroy(gameObject);
            }
        }

        IEnumerator ChangeFactor()
        {
            yield return new WaitForSeconds(0.1f);
            if (ActionType == "up")
            {
                if (Factor >= MaxFactor)
                    ActionType = "down";
                else
                    Factor++;
            }
            else
            {
                if (Factor <= MinFactor)
                    ActionType = "up";
                else
                    Factor--;
            }
            FactorText.text = "X" + Factor.ToString();
            StartCoroutine(ChangeFactor());
        }
    }
}