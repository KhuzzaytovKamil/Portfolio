using UnityEngine;
using ScriptableObjects.LvlsManager;
using ScriptableObjects.Economy;
using UnityEngine.SceneManagement;
using System;
using System.Globalization;


namespace Main
{
    public class ResetProgressController : MonoBehaviour
    {
        [SerializeField]
        PrizeManager PrizeManager;
        [SerializeField]
        MatchingCardsLvlsManager MatchingCardsLvlsManager;
        [SerializeField]
        FoodManager FoodManager;
        [SerializeField]
        ClassicLvlsManager ClassicLvlsManager;
        [SerializeField]
        PlayerSkinsManager PlayerSkinsManager;
        [SerializeField]
        PlateSkinManager PlateSkinManager;
        [SerializeField]
        HouseSkinManager HouseSkinManager;
        public void ResetProgress()
        {
            for (int clasicLvlNumber = ClassicLvlsManager.LvlNumber; clasicLvlNumber > 0; clasicLvlNumber--)
            {
                PlayerPrefs.SetInt("FalseNextBlockInLvl" + clasicLvlNumber, 0);
                PlayerPrefs.SetInt("StarsInLvl" + clasicLvlNumber, 0);
            }

            for (int MatchingCardsLvlNumber = MatchingCardsLvlsManager.LvlNumber; MatchingCardsLvlNumber > -1; MatchingCardsLvlNumber--)
                PlayerPrefs.SetInt("StarsInMatchingCardsLvl" + MatchingCardsLvlNumber, 0);

            for (int PlayerSkinsNumber = PlayerSkinsManager.SkinNumber; PlayerSkinsNumber > 0; PlayerSkinsNumber--)
                PlayerPrefs.SetInt("SkinBuyed" + PlayerSkinsNumber, 0);

            for (int PlateSkinsNumber = PlateSkinManager.PlateSkinNumber; PlateSkinsNumber > 0; PlateSkinsNumber--)
                PlayerPrefs.SetInt("PlateBuyedStatus" + PlateSkinsNumber, 0);

            for (int HouseSkinsNumber = HouseSkinManager.SkinNumber; HouseSkinsNumber > 0; HouseSkinsNumber--)
                PlayerPrefs.SetInt("HouseBuyedStatus" + HouseSkinsNumber, 0);

            for (int FoodNumber = FoodManager.TypeNumber - 1; FoodNumber > -1; FoodNumber--)
                PlayerPrefs.SetInt("Current" + FoodManager.FoodsName[FoodNumber] + "Number", 0);

            PlayerPrefs.SetInt("money", 0);
            PlayerPrefs.SetInt("EliteMoney", 0);
            PlayerPrefs.SetInt("Hearts", 0);

            PlayerPrefs.SetInt("SkinBuyed0", 1);
            PlayerPrefs.SetInt("PlateBuyedStatus0", 1);
            PlayerPrefs.SetInt("HouseBuyedStatus0", 1);

            PlayerPrefs.SetInt("ActiveSkinNumber", 0);
            PlayerPrefs.SetInt("UsedPlateSkinNumber", 0);
            PlayerPrefs.SetInt("UsedHouseSkinNumber", 0);

            PlayerPrefs.SetInt("LastLoginTime", (int)(DateTime.UtcNow - DateTime.ParseExact("2020-01-01 00:00:00Z", "u", CultureInfo.InvariantCulture)).TotalSeconds);
            PlayerPrefs.SetFloat("CurrentHungry", 0);
            SceneManager.LoadScene("MainMenu");

            PlayerPrefs.SetInt("CurrentPrize", 1);
            PlayerPrefs.SetFloat("HappinessPoint", PrizeManager.HappinessPointInStart);

            PlayerPrefs.SetInt("LastGetBigPrizeForAdTime", 90000);
        }
    }
}
