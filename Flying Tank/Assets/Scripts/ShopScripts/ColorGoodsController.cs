using UnityEngine;
using ScriptableObjects.Economy;
using UnityEngine.UI;

namespace Shop
{
    public class ColorGoodsController : MonoBehaviour
    {
        [SerializeField]
        int ColorNumber;
        [SerializeField]
        ColorsManager ColorsDataManager;
        [SerializeField]
        ColorInShopManager ColorInShopManager;
        [SerializeField]
        GameObject OutsideLineForUsedColor;
        [SerializeField]
        Text ColorPriceInBuyWindow;
        public Image ColorImageInBuyWindow;
        [SerializeField]
        GameObject ColorBuyWindow;
        void Start()
        {
            UpdateColorGoodsStatus();
            ColorInShopManager.ColorChangedEvent += UpdateColorGoodsStatus;
        }

        void OnEnable() => ColorInShopManager.ColorChangedEvent += UpdateColorGoodsStatus;
         
        void OnDisable() => ColorInShopManager.ColorChangedEvent -= UpdateColorGoodsStatus;
         
        void OnDestroy() => ColorInShopManager.ColorChangedEvent -= UpdateColorGoodsStatus;
         
        public void ClickToColor()
        {
            if (ColorsDataManager.BuyedStatus[ColorNumber] == false)
            {
                ColorImageInBuyWindow.color = ColorsDataManager.Color[ColorNumber];
                ColorPriceInBuyWindow.text = ColorsDataManager.Price[ColorNumber].ToString();
                ColorInShopManager.BuyColorNumber = ColorNumber;
                ColorBuyWindow.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetInt("UsedColorNumber", ColorNumber);
                ColorInShopManager.NewColorNumber = ColorNumber;
                ColorInShopManager.ColorChanged();
            }            
        }
        
        void UpdateColorGoodsStatus()
        {
            if (PlayerPrefs.GetInt("UsedColorNumber") == ColorNumber)
                OutsideLineForUsedColor.SetActive(true);
            else
                OutsideLineForUsedColor.SetActive(false);
        }
    }
}
