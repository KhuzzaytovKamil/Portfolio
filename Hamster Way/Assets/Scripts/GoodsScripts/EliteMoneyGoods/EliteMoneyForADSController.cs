using UnityEngine.UI;
using UnityEngine;
using ScriptableObjects.Economy;
using UnityAds;

namespace Goods
{
    public class EliteMoneyForADSController : MonoBehaviour
    {
        [SerializeField]
        Text NumberEliteMoneyText;
        [SerializeField]
        Image StackEliteMoneyImage;
        [SerializeField]
        EliteMoneyGoodsManager EliteMoneyGoodsManager;
        bool GiveThisPrize;
        void Start()
        {
            NumberEliteMoneyText.text = EliteMoneyGoodsManager.ADSNumberEliteMoney.ToString();
            StackEliteMoneyImage.sprite = EliteMoneyGoodsManager.SpriteForADSGoods;
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
                PlayerPrefs.SetInt("EliteMoney", PlayerPrefs.GetInt("EliteMoney") + EliteMoneyGoodsManager.ADSNumberEliteMoney);
                GiveThisPrize = false;
            }
        }
    }
}
