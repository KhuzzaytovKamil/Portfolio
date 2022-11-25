using UnityEngine;
using System;
using System.Globalization;
using ScriptableObjects.Economy;

namespace Main
{
    public class StartController : MonoBehaviour
    {
        [SerializeField]
        PrizeManager PrizeManager;
        [SerializeField]
        int WinWithoutAdsNumber;
        void Start()
        {
            if (PlayerPrefs.GetInt("IsNotStart") == 1)
                Destroy(gameObject); 
            else
            {
                PlayerPrefs.SetString("Language", "Russian");

                PlayerPrefs.SetInt("SkinBuyed0", 1);
                PlayerPrefs.SetInt("PlateBuyedStatus0", 1);
                PlayerPrefs.SetInt("HouseBuyedStatus0", 1);

                PlayerPrefs.SetInt("SOUND", 1);

                PlayerPrefs.SetInt("WinningWereAfterLastAd", 2 - WinWithoutAdsNumber);
                PlayerPrefs.SetInt("LastLoginTime", (int)(DateTime.UtcNow - DateTime.ParseExact("2020-01-01 00:00:00Z", "u", CultureInfo.InvariantCulture)).TotalSeconds);

                PlayerPrefs.SetFloat("CurrentHungry", 0.3f);
                PlayerPrefs.SetInt("CurrentPrize", 1);

                PlayerPrefs.SetFloat("HappinessPoint", PrizeManager.HappinessPointInStart);

                PlayerPrefs.SetInt("OverlookAdForBigPrize", 3);

                PlayerPrefs.SetInt("CurrentCornNumber", 3);
            }
            PlayerPrefs.SetInt("IsNotStart", 1);
        }
    }
}
