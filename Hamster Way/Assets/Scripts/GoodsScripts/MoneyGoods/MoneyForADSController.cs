using UnityEngine.UI;
using UnityEngine;
using ScriptableObjects.Economy;
using UnityAds;

namespace Goods
{
    public class MoneyForADSController : MonoBehaviour
    {
        [SerializeField]
        Text NumberMoneyText;
        [SerializeField]
        Image StackMoneyImage;
        [SerializeField]
        MoneyGoodsManager MoneyGoodsManager;
        bool GiveThisPrize;
        void Start()
        {
            NumberMoneyText.text = MoneyGoodsManager.ADSNumberMoney.ToString();
            StackMoneyImage.sprite = MoneyGoodsManager.SpriteForADSGoods;
            UnityAdsRewardedManager.UnityAdsShowComplete += WatchADS;
        }
        void OnEnable() => UnityAdsRewardedManager.UnityAdsShowComplete += WatchADS;
        
        void OnDisable() => UnityAdsRewardedManager.UnityAdsShowComplete -= WatchADS;
        
        void OnDestroy() => UnityAdsRewardedManager.UnityAdsShowComplete -= WatchADS;
        
        public void ThisPrize() => GiveThisPrize = true;
        
        void WatchADS()
        {
            if (GiveThisPrize)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + MoneyGoodsManager.ADSNumberMoney);
                GiveThisPrize = false;
            }
        }
    }
}
