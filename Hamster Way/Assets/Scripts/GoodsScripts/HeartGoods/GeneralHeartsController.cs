using UnityEngine.UI;
using UnityEngine;
using ScriptableObjects.Economy;

namespace Goods
{
    public class GeneralHeartsController : MonoBehaviour
    {
        [SerializeField]
        int GoodsNumber;
        [SerializeField]
        Text NumberHeatsText;
        [SerializeField]
        Text PriceText;
        [SerializeField]
        Image StackHeatsImage;
        [SerializeField]
        HeartsGoodsManager HeartsGoodsManager;
        void Start()
        {
            NumberHeatsText.text = HeartsGoodsManager.NumberHeats[GoodsNumber].ToString();
            PriceText.text = HeartsGoodsManager.PriceInCoins[GoodsNumber].ToString();
            StackHeatsImage.sprite = HeartsGoodsManager.SpriteForThisGoods[GoodsNumber];
        }
        public void BuyHearts()
        {
            if (HeartsGoodsManager.PriceInCoins[GoodsNumber] <= PlayerPrefs.GetInt("money"))
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - HeartsGoodsManager.PriceInCoins[GoodsNumber]);
                PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") + HeartsGoodsManager.NumberHeats[GoodsNumber]);
            }
        }
    }
}
