using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.LvlsManager;
using Audio;
using UnityAds;
using UnityEngine.SceneManagement;

namespace Finish.MatchingCardsLvlFinishSystem
{
    public class MatchingCardsLvlWinWindowController : MonoBehaviour
    {
        int HeartsForTheFirstHeartsPack;
        int HeartsForTheSecondHeartsPack;
        int HeartsForTheThirdHeartsPack;
        int AllHeartsForLvl;
        [Header("Scripts:")]
        [SerializeField]
        UnityAdsInterstitialManager UnityAdsInterstitialManager;
        [SerializeField]
        MatchingCardsLvlsManager LvlManager;
        [Header("Texts:")]
        [SerializeField]
        Text AllHeartsForLvlText;
        [Header("Sounds:")]
        [SerializeField]
        AudioSource WinAudio;
        void Start()
        {
            if (PlayerPrefs.GetInt("WinningWereAfterLastAd") == 2)
            {
                UnityAdsInterstitialManager.ShowAd();
                PlayerPrefs.SetInt("WinningWereAfterLastAd", 0);
            }
            else
                PlayerPrefs.SetInt("WinningWereAfterLastAd", PlayerPrefs.GetInt("WinningWereAfterLastAd") + 1);
            HeartsForTheFirstHeartsPack = Mathf.RoundToInt(LvlManager.HeartsForTheFirstHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * PlayerPrefs.GetFloat("FactorForPrize"));
            HeartsForTheSecondHeartsPack = Mathf.RoundToInt(LvlManager.HeartsForTheSecondHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * PlayerPrefs.GetFloat("FactorForPrize"));
            HeartsForTheThirdHeartsPack = Mathf.RoundToInt(LvlManager.HeartsForTheThirdHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * PlayerPrefs.GetFloat("FactorForPrize"));

            SoundController.PLAY_THIS_SOUND(WinAudio);
            if (PlayerPrefs.GetInt("Stars") >= 1)
            {
                PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") + HeartsForTheFirstHeartsPack);
                AllHeartsForLvl += HeartsForTheFirstHeartsPack;
            }
            if (PlayerPrefs.GetInt("Stars") >= 2)
            {
                PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") + HeartsForTheSecondHeartsPack);
                AllHeartsForLvl += HeartsForTheSecondHeartsPack;
            }
            if (PlayerPrefs.GetInt("Stars") == 3)
            {
                PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") + HeartsForTheThirdHeartsPack);
                AllHeartsForLvl += HeartsForTheThirdHeartsPack;
            }

            AllHeartsForLvlText.text = "+" + AllHeartsForLvl.ToString();

            if (PlayerPrefs.GetFloat("HeartsFactor") > 1)
            {
                AllHeartsForLvlText.text = "+" + AllHeartsForLvl.ToString() + "(" + Mathf.Round(AllHeartsForLvl * PlayerPrefs.GetFloat("HeartsFactor")) + ")";
                PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") + Mathf.RoundToInt(AllHeartsForLvl * (PlayerPrefs.GetFloat("HeartsFactor") - 1)));
            }

            if (PlayerPrefs.GetFloat("FactorForPrize") == LvlManager.PrizeFactorForEasy)
                PlayerPrefs.SetInt("StarsInMatchingCardsLvl" + PlayerPrefs.GetInt("MatchingCardsLvlNumber"), 1);
            else if (PlayerPrefs.GetFloat("FactorForPrize") == LvlManager.PrizeFactorForMiddle)
                PlayerPrefs.SetInt("StarsInMatchingCardsLvl" + PlayerPrefs.GetInt("MatchingCardsLvlNumber"), 2);
            else
                PlayerPrefs.SetInt("StarsInMatchingCardsLvl" + PlayerPrefs.GetInt("MatchingCardsLvlNumber"), 3);
        }

        public void OpenNextLvl()
        {
            if (PlayerPrefs.GetInt("StarsInMatchingCardsLvl" + PlayerPrefs.GetInt("MatchingCardsLvlNumber")) == 1)
            {
                PlayerPrefs.SetFloat("FactorForOpening", LvlManager.MiddleFactorForOpening);
                PlayerPrefs.SetFloat("FactorForPrize", LvlManager.MiddleFactorForPrize);
            }
            else if (PlayerPrefs.GetInt("StarsInMatchingCardsLvl" + PlayerPrefs.GetInt("MatchingCardsLvlNumber")) == 2)
            {
                PlayerPrefs.SetFloat("FactorForOpening", LvlManager.HardFactorForOpening);
                PlayerPrefs.SetFloat("FactorForPrize", LvlManager.HardFactorForPrize);
            }
            else if (PlayerPrefs.GetInt("StarsInMatchingCardsLvl" + PlayerPrefs.GetInt("MatchingCardsLvlNumber")) == 3)
            {
                PlayerPrefs.SetInt("MatchingCardsLvlNumber", PlayerPrefs.GetInt("MatchingCardsLvlNumber") + 1);
                PlayerPrefs.SetFloat("FactorForOpening", LvlManager.EasyFactorForOpening);
                PlayerPrefs.SetFloat("FactorForPrize", LvlManager.EasyFactorForPrize);
            }

            SceneManager.LoadScene("MatchingCardsLvl");
        }
    }
}
