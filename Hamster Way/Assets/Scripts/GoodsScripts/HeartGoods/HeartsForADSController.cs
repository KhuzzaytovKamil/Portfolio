using UnityEngine.UI;
using UnityEngine;
using ScriptableObjects.Economy;
using UnityAds;

namespace Goods
{
    public class HeartsForADSController : MonoBehaviour
    {
        [SerializeField]
        Text NumberHeartsText;
        [SerializeField]
        Image StackHeartsImage;
        [SerializeField]
        HeartsGoodsManager HeartsGoodsManager;
        bool GiveThisPrize;
        void Start()
        {
            NumberHeartsText.text = HeartsGoodsManager.ADSNumberHeats.ToString();
            StackHeartsImage.sprite = HeartsGoodsManager.SpriteForADSGoods;
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
                PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") + HeartsGoodsManager.ADSNumberHeats);
                GiveThisPrize = false;
            }
        }
    }
}