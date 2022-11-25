using UnityEngine;
using System;
using ScriptableObjects.Economy;
using Scroll;
using UnityEngine.SceneManagement;

namespace HouseSkin
{
    public class HouseSkinInShopManager : MonoBehaviour
    {
        public static event Action SkinChangedEvent;
        public int BuySkinNumber = -1;
        [SerializeField]
        HouseSkinManager SkinDataManager;
        [SerializeField]
        GameObject SkinBuyWindow;
        [SerializeField]
        OpenSamePlaceInScroll OpenSamePlaceInScrollController;
        public void SkinChanged() => SkinChangedEvent.Invoke();

        public void BuySkin()
        {
            if (SkinDataManager.Price[BuySkinNumber] <= PlayerPrefs.GetInt("money"))
            {
                PlayerPrefs.SetInt("HouseBuyedStatus" + BuySkinNumber, 1);
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - SkinDataManager.Price[BuySkinNumber]);
                PlayerPrefs.SetInt("UsedHouseSkinNumber", BuySkinNumber);
                SkinChanged();
                SkinBuyWindow.SetActive(false);
            }
            else
            {
                SceneManager.LoadScene("CurrencyShop");
                OpenSamePlaceInScrollController.SwitchScrollContentPosition();
            }
        }
    }
}