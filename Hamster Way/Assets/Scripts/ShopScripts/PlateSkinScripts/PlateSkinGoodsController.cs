using UnityEngine;
using ScriptableObjects.Economy;
using UnityEngine.UI;

namespace PlateSkin
{
    public class PlateSkinGoodsController : MonoBehaviour
    {
        [SerializeField]
        int SkinNumber;
        [SerializeField]
        PlateSkinManager SkinDataManager;
        [SerializeField]
        PlateSkinInShopManager PlateSkinInShopManager;
        [SerializeField]
        GameObject TextForUsedSkin;
        [SerializeField]
        GameObject PriceScreen;
        [SerializeField]
        Text SkinPrice;
        [SerializeField]
        Text SkinPriceInBuyWindow;
        public Image SkinImageInBuyWindow;
        [SerializeField]
        GameObject BuyWindow;
        [SerializeField]
        Image SkinImage;
        void Start()
        {
            SkinImage.sprite = SkinDataManager.StandardPlateSprite[SkinNumber];
            SkinPrice.text = SkinDataManager.Price[SkinNumber].ToString();
            UpdatePlateSkinGoodsStatus();
            PlateSkinInShopManager.SkinChangedEvent += UpdatePlateSkinGoodsStatus;
        }

        void OnEnable() => PlateSkinInShopManager.SkinChangedEvent += UpdatePlateSkinGoodsStatus;
         
        void OnDisable() => PlateSkinInShopManager.SkinChangedEvent -= UpdatePlateSkinGoodsStatus;
         
        void OnDestroy() => PlateSkinInShopManager.SkinChangedEvent -= UpdatePlateSkinGoodsStatus;
         
        public void ClickToPlateSkin()
        {
            if (PlayerPrefs.GetInt("PlateBuyedStatus" + SkinNumber) == 0)
            {
                SkinImageInBuyWindow.sprite = SkinDataManager.StandardPlateSprite[SkinNumber];
                SkinPriceInBuyWindow.text = SkinDataManager.Price[SkinNumber].ToString();
                PlateSkinInShopManager.BuySkinNumber = SkinNumber;
                BuyWindow.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetInt("UsedPlateSkinNumber", SkinNumber);
                PlateSkinInShopManager.SkinChanged();
            }            
        }
        
        void UpdatePlateSkinGoodsStatus()
        {
            if (PlayerPrefs.GetInt("PlateBuyedStatus" + SkinNumber) == 1)
            {
                Destroy(PriceScreen);
                if (PlayerPrefs.GetInt("UsedPlateSkinNumber") == SkinNumber)
                    TextForUsedSkin.SetActive(true);
                else
                    TextForUsedSkin.SetActive(false);
            }
        }
    }
}
