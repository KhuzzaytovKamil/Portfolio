using UnityEngine;
using System;
using ScriptableObjects.Economy;
using Scroll;
using UnityEngine.SceneManagement;

namespace Shop
{
    public class ColorInShopManager : MonoBehaviour
    {
        public static event Action ColorChangedEvent;
        public int NewColorNumber = -1;
        public int BuyColorNumber = -1;
        [SerializeField]
        GameObject ParticleSystem;
        [SerializeField]
        ColorsManager ColorsDataManager;
        [SerializeField]
        GameObject ColorBuyWindow;
        [SerializeField]
        OpenSamePlaceInScroll OpenSamePlaceInScrollController;
        public void ColorChanged() => ColorChangedEvent.Invoke();

        void Start()
        {
            ColorChangedEvent += SetColorToPlayerInShop;
            gameObject.GetComponent<Renderer>().material = ColorsDataManager.ColorMaterial[PlayerPrefs.GetInt("UsedColorNumber")];
        }

        void OnEnable() => ColorChangedEvent += SetColorToPlayerInShop;

        void OnDisable() => ColorChangedEvent -= SetColorToPlayerInShop;

        void OnDestroy() => ColorChangedEvent -= SetColorToPlayerInShop;

        void SetColorToPlayerInShop()
        {
            if (NewColorNumber != PlayerPrefs.GetInt("UsedColorNumber"))
            {
                ParticleSystem.SetActive(false);
                ParticleSystem.SetActive(true);
                gameObject.GetComponent<Renderer>().material = ColorsDataManager.ColorMaterial[PlayerPrefs.GetInt("UsedColorNumber")];
            }
        }

        public void BuyColor()
        {
            if (ColorsDataManager.Price[BuyColorNumber] <= PlayerPrefs.GetInt("money"))
            {
                ColorsDataManager.BuyedStatus[BuyColorNumber] = true;
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - ColorsDataManager.Price[BuyColorNumber]);
                PlayerPrefs.SetInt("UsedColorNumber", BuyColorNumber);
                NewColorNumber = BuyColorNumber;
                ColorChanged();
                ColorBuyWindow.SetActive(false);
            }
            else
            {
                SceneManager.LoadScene("Money&EliteMoneyShop");
                OpenSamePlaceInScrollController.SwitchScrollContentPosition();
            }
        }
    }
}