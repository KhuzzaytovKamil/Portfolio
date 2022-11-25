using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Economy;
using UnityEngine.SceneManagement;

namespace Goods
{
    public class ChestGoodsController : MonoBehaviour
    {
        [SerializeField]
        Text PriceText;
        [SerializeField]
        ChestManager ChestManager;
        [SerializeField]
        Image ChestImage;
        int Price;
        [SerializeField]
        ChestType ChestGoodsType;
        enum ChestType { LowChest, MiddleChest, HighChest}

        void Start()
        {
            if (ChestGoodsType == ChestType.LowChest)
            {
                Price = ChestManager.LowChestPriceInEliteMoney;
                ChestImage.sprite = ChestManager.LowChestSprite;
            }
            else if (ChestGoodsType == ChestType.MiddleChest)
            {
                Price = ChestManager.MiddleChestPriceInEliteMoney;
                ChestImage.sprite = ChestManager.MiddleChestSprite;
            }
            else if (ChestGoodsType == ChestType.HighChest)
            {
                Price = ChestManager.HighChestPriceInEliteMoney;
                ChestImage.sprite = ChestManager.HighChestSprite;
            }
            PriceText.text = Price.ToString();
        }

        public void BuyChest()
        {
            if (Price <= PlayerPrefs.GetInt("EliteMoney"))
            {
                PlayerPrefs.SetInt("EliteMoney", PlayerPrefs.GetInt("EliteMoney") - Price);
                if (ChestGoodsType == ChestType.LowChest)
                {
                    PlayerPrefs.SetInt("Stars", 1);
                    SceneManager.LoadScene("ChestScene");
                }
                else if (ChestGoodsType == ChestType.MiddleChest)
                {
                    PlayerPrefs.SetInt("Stars", 2);
                    SceneManager.LoadScene("ChestScene");
                }
                else if (ChestGoodsType == ChestType.HighChest)
                {
                    PlayerPrefs.SetInt("Stars", 3);
                    SceneManager.LoadScene("ChestScene");
                }
            }
        }
    }
}