using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LvlGenerator;
using UnityAds;

namespace Goods
{
    public class LvlExtraPrizesForADSController : MonoBehaviour
    {
        [SerializeField]
        int Factor;
        [SerializeField]
        int MinFactor;
        [SerializeField]
        int MaxFactor;
        string ActionType = "up";
        [SerializeField]
        PlatformGeneratorManager LvlManager;
        int CoinsForAds;
        int EliteMoneyForAds;
        [SerializeField]
        Text CoinsForAdsText;
        [SerializeField]
        Text EliteMoneyForAdsText;
        [SerializeField]
        Text FactorText;
        bool GiveThisPrize;
        [SerializeField]
        GameObject ExtraPrizesWindow;
        int StarsInLvlInStart;
        [SerializeField]
        Text AllEliteMoneyForLvlText;
        [SerializeField]
        Text AllCoinsForLvlText;
        void Start()
        {
            if (PlayerPrefs.GetInt("StarsInLvl" + LvlManager.LvlNumber) == 3)
                gameObject.SetActive(false);
            StarsInLvlInStart = PlayerPrefs.GetInt("StarsInLvl" + LvlManager.LvlNumber);
            UnityAdsRewardedManager.UnityAdsShowComplete += GetExtraPrizes;
        }

        void OnEnable()
        {
            StartCoroutine(ChangeFactor());
            UnityAdsRewardedManager.UnityAdsShowComplete += GetExtraPrizes;
        }

        void OnDisable() => UnityAdsRewardedManager.UnityAdsShowComplete -= GetExtraPrizes;

        void OnDestroy() => UnityAdsRewardedManager.UnityAdsShowComplete -= GetExtraPrizes;

        public void ThisPrize() => GiveThisPrize = true;
        

        void GetExtraPrizes()
        {
            if (GiveThisPrize)
            {
                if (StarsInLvlInStart < 1 && PlayerPrefs.GetInt("Stars") >= 1)
                {
                    CoinsForAds += LvlManager.MoneyForTheFirstStar * (Factor - 1);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + LvlManager.MoneyForTheFirstStar * (Factor - 1));
                }
                if (StarsInLvlInStart < 2 && PlayerPrefs.GetInt("Stars") >= 2)
                {
                    CoinsForAds += LvlManager.MoneyForTheSecondStar * (Factor - 1);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + LvlManager.MoneyForTheSecondStar * (Factor - 1));
                }
                if (StarsInLvlInStart < 3 && PlayerPrefs.GetInt("Stars") == 3)
                {
                    if (LvlManager.EliteMoneyForTheThirdStar == 0)
                    {
                        CoinsForAds += LvlManager.MoneyForTheThirdStar * (Factor - 1);
                        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + LvlManager.MoneyForTheThirdStar * (Factor - 1));
                    }
                    else
                    {
                        EliteMoneyForAds += LvlManager.EliteMoneyForTheThirdStar * (Factor - 1);
                        PlayerPrefs.SetInt("EliteMoney", PlayerPrefs.GetInt("EliteMoney") + LvlManager.EliteMoneyForTheThirdStar * (Factor - 1));
                    }
                }
            }
                CoinsForAdsText.text = CoinsForAds.ToString();
                EliteMoneyForAdsText.text = EliteMoneyForAds.ToString();
                AllCoinsForLvlText.text = (CoinsForAds * Factor).ToString();
                AllEliteMoneyForLvlText.text = (EliteMoneyForAds * Factor).ToString();
                ExtraPrizesWindow.SetActive(true);
                GiveThisPrize = false;
                Destroy(gameObject);
        }

        IEnumerator ChangeFactor()
        {
            yield return new WaitForSeconds(0.1f);
            if (ActionType == "up")
            {
                if (Factor >= MaxFactor)
                    ActionType = "down";
                else
                    Factor ++;
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
