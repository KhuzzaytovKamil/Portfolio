using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ClassicLvlGenerator;
using Audio;
using UnityAds;
using ScriptableObjects.LvlsManager;

namespace Finish.ClassicLvlFinishSystem
{
    public class ClassicLvlWinWindowController : MonoBehaviour
    {
        int AllEliteMoneyForLvl;
        int AllCoinsForLvl;
        [SerializeField]
        Image TheThirdStarPrizeImage;
        [SerializeField]
        Sprite CoinSprite;
        [SerializeField]
        Sprite EliteMoneySprite;
        [SerializeField]
        float WaitBetweenSetActiveStar;
        [Header("Scripts:")]
        [SerializeField]
        UnityAdsInterstitialManager UnityAdsInterstitialManager;
        [SerializeField]
        ClassicLvlSettingsManager LvlManager;
        [SerializeField]
        ClassicLvlsManager ClassicLvlsManager;
        [Header("Objects:")]
        [SerializeField]
        GameObject TheFirstStar;
        [SerializeField]
        GameObject TheSecondStar;
        [SerializeField]
        GameObject TheThirdStar;
        [SerializeField]
        GameObject GotMoneyAnim;
        [SerializeField]
        GameObject Buttons;
        [SerializeField]
        GameObject NextLvlButton;
        [SerializeField]
        GameObject AllEliteMoneyForLvlWindow;
        [Header("Texts:")]
        [SerializeField]
        Text NumberPrizeForTheFirstStar;
        [SerializeField]
        Text NumberPrizeForTheSecondStar;
        [SerializeField]
        Text NumberPrizeForTheThirdStar;
        [SerializeField]
        Text AllEliteMoneyForLvlText;
        [SerializeField]
        Text AllCoinsForLvlText;
        [Header("Sounds:")]
        [SerializeField]
        AudioSource WinAudio;
        [SerializeField]
        AudioSource GotStarAudio;
        [SerializeField]
        AudioSource GotMoneyAudio;

        void Start()
        {
            if (LvlManager.LvlNumber == ClassicLvlsManager.CurrentLastLvlNumber)
                Destroy(NextLvlButton);
            if (PlayerPrefs.GetInt("WinningWereAfterLastAd") == 2)
            {
                UnityAdsInterstitialManager.ShowAd();
                PlayerPrefs.SetInt("WinningWereAfterLastAd", 0);
            }
            else
                PlayerPrefs.SetInt("WinningWereAfterLastAd", PlayerPrefs.GetInt("WinningWereAfterLastAd") + 1);
            NumberPrizeForTheFirstStar.text = LvlManager.MoneyForTheFirstStar.ToString();
            NumberPrizeForTheSecondStar.text = LvlManager.MoneyForTheSecondStar.ToString();
            if (LvlManager.EliteMoneyForTheThirdStar == 0)
                NumberPrizeForTheThirdStar.text = LvlManager.MoneyForTheThirdStar.ToString();
            else
                NumberPrizeForTheThirdStar.text = LvlManager.EliteMoneyForTheThirdStar.ToString();
            if (LvlManager.EliteMoneyForTheThirdStar == 0)
                TheThirdStarPrizeImage.sprite = CoinSprite;
            else
                TheThirdStarPrizeImage.sprite = EliteMoneySprite;

            StartCoroutine(GetPrizes());

            if (PlayerPrefs.GetInt("StarsInLvl" + LvlManager.LvlNumber) == 3)
            {
                TheThirdStar.SetActive(true);
                Buttons.SetActive(true);
            }
            if (PlayerPrefs.GetInt("StarsInLvl" + LvlManager.LvlNumber) >= 2)
                TheSecondStar.SetActive(true);
            if (PlayerPrefs.GetInt("StarsInLvl" + LvlManager.LvlNumber) >= 1)
                TheFirstStar.SetActive(true);
            if (PlayerPrefs.GetInt("StarsInLvl" + LvlManager.LvlNumber) == PlayerPrefs.GetInt("Stars"))
                Buttons.SetActive(true);

            PlayerPrefs.SetInt("FalseNextBlockInLvl" + LvlManager.LvlNumber, 1);
        }
        IEnumerator GetPrizes()
        {
            yield return new WaitForSeconds(0.5f);
            SoundController.PLAY_THIS_SOUND(WinAudio);
            if (PlayerPrefs.GetInt("StarsInLvl" + LvlManager.LvlNumber) < 1 && PlayerPrefs.GetInt("Stars") >= 1)
            {
                TheFirstStar.SetActive(true);
                TheFirstStar.GetComponent<Animator>().SetBool("GetStar", true);
                PlayerPrefs.SetInt("StarsInLvl" + LvlManager.LvlNumber, 1);
                SoundController.PLAY_THIS_SOUND(GotStarAudio);
                SoundController.PLAY_THIS_SOUND(GotMoneyAudio);
                GotMoneyAnim.SetActive(true);
                AllCoinsForLvl += LvlManager.MoneyForTheFirstStar;
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + LvlManager.MoneyForTheFirstStar);
                if (PlayerPrefs.GetInt("Stars") == 1)
                {
                    AllCoinsForLvlText.text = "+" + AllCoinsForLvl.ToString();
                    AllEliteMoneyForLvlText.text = "+" + AllEliteMoneyForLvl.ToString();
                    Buttons.SetActive(true);
                    if (PlayerPrefs.GetFloat("MoneyFactor") > 1)
                    {
                        AllCoinsForLvlText.text = "+" + AllCoinsForLvl.ToString() + "(" + Mathf.Round(AllCoinsForLvl * PlayerPrefs.GetFloat("MoneyFactor")) + ")";
                        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + Mathf.RoundToInt(LvlManager.MoneyForTheFirstStar * (PlayerPrefs.GetFloat("MoneyFactor") - 1)));
                    }
                }
            }
            if (PlayerPrefs.GetInt("StarsInLvl" + LvlManager.LvlNumber) < 2 && PlayerPrefs.GetInt("Stars") >= 2)
                StartCoroutine(SetTheSecondStar(WaitBetweenSetActiveStar));
            else if (PlayerPrefs.GetInt("StarsInLvl" + LvlManager.LvlNumber) != 3 && PlayerPrefs.GetInt("Stars") == 3)
                StartCoroutine(SetTheThirdStar(WaitBetweenSetActiveStar));
        }
        IEnumerator SetTheSecondStar(float WaitBetweenSetActiveStar)
        {
            yield return new WaitForSeconds(WaitBetweenSetActiveStar);
            TheSecondStar.SetActive(true);
            TheSecondStar.GetComponent<Animator>().SetBool("GetStar", true);
            PlayerPrefs.SetInt("StarsInLvl" + LvlManager.LvlNumber, 2);
            SoundController.PLAY_THIS_SOUND(GotStarAudio);
            SoundController.PLAY_THIS_SOUND(GotMoneyAudio);
            GotMoneyAnim.SetActive(true);
            AllCoinsForLvl += LvlManager.MoneyForTheSecondStar;
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + LvlManager.MoneyForTheSecondStar);
            if (PlayerPrefs.GetInt("Stars") == 2)
            {
                AllCoinsForLvlText.text = "+" + AllCoinsForLvl.ToString();
                AllEliteMoneyForLvlText.text = "+" + AllEliteMoneyForLvl.ToString();
                Buttons.SetActive(true);
                if (PlayerPrefs.GetFloat("MoneyFactor") > 1)
                {
                    AllCoinsForLvlText.text = "+" + AllCoinsForLvl.ToString() + "(" + Mathf.Round(AllCoinsForLvl * PlayerPrefs.GetFloat("MoneyFactor")) + ")";
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + Mathf.RoundToInt(LvlManager.MoneyForTheSecondStar * (PlayerPrefs.GetFloat("MoneyFactor") - 1)));
                }
            }
            else
            {
                StartCoroutine(SetTheThirdStar(WaitBetweenSetActiveStar));
            }
        }
        IEnumerator SetTheThirdStar(float WaitBetweenSetActiveStar)
        {
            yield return new WaitForSeconds(WaitBetweenSetActiveStar);
            TheThirdStar.SetActive(true);
            TheThirdStar.GetComponent<Animator>().SetBool("GetStar", true);
            PlayerPrefs.SetInt("StarsInLvl" + LvlManager.LvlNumber, 3);
            SoundController.PLAY_THIS_SOUND(GotStarAudio);
            SoundController.PLAY_THIS_SOUND(GotMoneyAudio);
            GotMoneyAnim.SetActive(true);
            if (PlayerPrefs.GetInt("Stars") == 3)
                Buttons.SetActive(true);
            if (LvlManager.EliteMoneyForTheThirdStar == 0)
            {
                AllCoinsForLvl += LvlManager.MoneyForTheThirdStar;
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + LvlManager.MoneyForTheThirdStar);
            }
            else
            {
                AllEliteMoneyForLvl += LvlManager.EliteMoneyForTheThirdStar;
                PlayerPrefs.SetInt("EliteMoney", PlayerPrefs.GetInt("EliteMoney") + LvlManager.EliteMoneyForTheThirdStar);
                AllEliteMoneyForLvlWindow.SetActive(true);
                if (PlayerPrefs.GetFloat("MoneyFactor") > 1)
                {
                    AllCoinsForLvlText.text = "+" + AllCoinsForLvl.ToString() + "(" + Mathf.Round(AllCoinsForLvl * PlayerPrefs.GetFloat("MoneyFactor")) + ")";
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + Mathf.RoundToInt(LvlManager.MoneyForTheThirdStar * (PlayerPrefs.GetFloat("MoneyFactor") - 1)));
                }

                if (PlayerPrefs.GetFloat("EliteMoneyFactor") > 1)
                {
                    AllEliteMoneyForLvlText.text = "+" + AllEliteMoneyForLvl.ToString() + "(" + Mathf.Round(AllEliteMoneyForLvl * PlayerPrefs.GetFloat("EliteMoneyFactor")) + ")";
                    PlayerPrefs.SetInt("EliteMoney", PlayerPrefs.GetInt("EliteMoney") + Mathf.RoundToInt(LvlManager.EliteMoneyForTheThirdStar * (PlayerPrefs.GetFloat("EliteMoneyFactor") - 1)));
                }
            }

            AllCoinsForLvlText.text = "+" + AllCoinsForLvl.ToString();
            AllEliteMoneyForLvlText.text = "+" + AllEliteMoneyForLvl.ToString();
        }
    }
}
