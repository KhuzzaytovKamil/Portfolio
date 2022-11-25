using UnityEngine;
using ScriptableObjects.Economy;
using UnityEngine.UI;

namespace HouseSkin
{
    public class HouseSkinGoodsController : MonoBehaviour
    {
        [SerializeField]
        int SkinNumber;
        [SerializeField]
        HouseSkinManager SkinDataManager;
        [SerializeField]
        HouseSkinInShopManager HouseSkinInShopManager;
        [SerializeField]
        GameObject TextForUsedSkin;
        [SerializeField]
        GameObject CreatureInHouse;
        [SerializeField]
        GameObject PriceScreen;
        [SerializeField]
        Text SkinPrice;
        [SerializeField]
        Text SkinPriceInBuyWindow;
        [SerializeField]
        GameObject BuyWindow;
        [Header("Images:")]
        [SerializeField]
        Image FGForSkinImage;
        [SerializeField]
        Image BGForSkinImage;
        [SerializeField]
        Image BGForSkinImageInBuyWindow;
        [SerializeField]
        Image FGForSkinImageInBuyWindow;
        void Start()
        {
            BGForSkinImage.color = SkinDataManager.ColorForBG[SkinNumber];
            FGForSkinImage.sprite = SkinDataManager.SpriteForFG[SkinNumber];
            SkinPrice.text = SkinDataManager.Price[SkinNumber].ToString();
            UpdateSkinGoodsStatus();
            HouseSkinInShopManager.SkinChangedEvent += UpdateSkinGoodsStatus;
        }

        void OnEnable() => HouseSkinInShopManager.SkinChangedEvent += UpdateSkinGoodsStatus;
         
        void OnDisable() => HouseSkinInShopManager.SkinChangedEvent -= UpdateSkinGoodsStatus;
         
        void OnDestroy() => HouseSkinInShopManager.SkinChangedEvent -= UpdateSkinGoodsStatus;
         
        public void ClickToSkin()
        {
            if (PlayerPrefs.GetInt("HouseBuyedStatus" + SkinNumber) == 0)
            {
                BGForSkinImageInBuyWindow.color = SkinDataManager.ColorForBG[SkinNumber];
                FGForSkinImageInBuyWindow.sprite = SkinDataManager.SpriteForFG[SkinNumber];
                SkinPriceInBuyWindow.text = SkinDataManager.Price[SkinNumber].ToString();
                HouseSkinInShopManager.BuySkinNumber = SkinNumber;
                BuyWindow.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetInt("UsedHouseSkinNumber", SkinNumber);
                HouseSkinInShopManager.SkinChanged();
            }            
        }
        
        void UpdateSkinGoodsStatus()
        {
            if (PlayerPrefs.GetInt("HouseBuyedStatus" + SkinNumber) == 1)
            {
                Destroy(PriceScreen);
                if (PlayerPrefs.GetInt("UsedHouseSkinNumber") == SkinNumber)
                {
                    CreatureInHouse.SetActive(true);
                    TextForUsedSkin.SetActive(true);
                }
                else
                {
                    CreatureInHouse.SetActive(false);
                    TextForUsedSkin.SetActive(false);
                }
            }
        }
    }
}
