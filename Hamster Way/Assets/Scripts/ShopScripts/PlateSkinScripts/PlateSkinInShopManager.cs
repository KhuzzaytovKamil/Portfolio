using UnityEngine;
using System;
using ScriptableObjects.Economy;
using Scroll;
using UnityEngine.SceneManagement;

namespace PlateSkin
{
    public class PlateSkinInShopManager : MonoBehaviour
    {
        public static event Action SkinChangedEvent;
        public int BuySkinNumber = -1;
        [SerializeField]
        PlateSkinManager SkinDataManager;
        [SerializeField]
        GameObject SkinBuyWindow;
        [SerializeField]
        OpenSamePlaceInScroll OpenSamePlaceInScrollController;
        public void SkinChanged() => SkinChangedEvent.Invoke();

        public void BuySkin()
        {
            if (SkinDataManager.Price[BuySkinNumber] <= PlayerPrefs.GetInt("money"))
            {
                PlayerPrefs.SetInt("PlateBuyedStatus" + BuySkinNumber, 1);
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - SkinDataManager.Price[BuySkinNumber]);
                PlayerPrefs.SetInt("UsedPlateSkinNumber", BuySkinNumber);
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