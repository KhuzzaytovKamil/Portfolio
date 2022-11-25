using UnityEngine.UI;
using UnityEngine;
using ScriptableObjects.Economy;

namespace Goods
{
    public class GeneralMoneyController : MonoBehaviour
    {
        [SerializeField]
        int MoneyGoodsNumber;
        [SerializeField]
        Text NumberMoneyText;
        [SerializeField]
        Text PriceText;
        [SerializeField]
        Image StackMoneyImage;
        [SerializeField]
        MoneyGoodsManager MoneyGoodsManager;
        void Start()
        {
            NumberMoneyText.text = MoneyGoodsManager.NumberMoney[MoneyGoodsNumber].ToString();
            PriceText.text = MoneyGoodsManager.PriceInEliteMoney[MoneyGoodsNumber].ToString();
            StackMoneyImage.sprite = MoneyGoodsManager.SpriteForThisGoods[MoneyGoodsNumber];
        }
        public void BuyMoney()
        {
            if (MoneyGoodsManager.PriceInEliteMoney[MoneyGoodsNumber] <= PlayerPrefs.GetInt("EliteMoney"))
            {
                PlayerPrefs.SetInt("EliteMoney", PlayerPrefs.GetInt("EliteMoney") - MoneyGoodsManager.PriceInEliteMoney[MoneyGoodsNumber]);
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + MoneyGoodsManager.NumberMoney[MoneyGoodsNumber]);
            }
        }
    }
}
