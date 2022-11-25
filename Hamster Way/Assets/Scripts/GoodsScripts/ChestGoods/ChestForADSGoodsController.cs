using UnityEngine.UI;
using UnityEngine;
using ScriptableObjects.Economy;
using UnityAds;
using UnityEngine.SceneManagement;

namespace Goods
{
    public class ChestForADSGoodsController : MonoBehaviour
    {
        [SerializeField]
        Image ChestImage;
        [SerializeField]
        ChestManager ChestManager;
        bool GiveThisPrize;
        [SerializeField]
        ChestType ChestGoodsType;
        enum ChestType { LowChest, MiddleChest, HighChest }
        void Start()
        {
            if (ChestGoodsType == ChestType.LowChest)
                ChestImage.sprite = ChestManager.LowChestSprite;
            else if (ChestGoodsType == ChestType.MiddleChest)
                ChestImage.sprite = ChestManager.MiddleChestSprite;
            else if (ChestGoodsType == ChestType.HighChest)
                ChestImage.sprite = ChestManager.HighChestSprite;
        }
        void OnEnable() => UnityAdsRewardedManager.UnityAdsShowComplete += WatchADS;

        void OnDisable() => UnityAdsRewardedManager.UnityAdsShowComplete -= WatchADS;

        void OnDestroy() => UnityAdsRewardedManager.UnityAdsShowComplete -= WatchADS;

        public void ThisPrize() => GiveThisPrize = true;

        void WatchADS()
        {
            if (GiveThisPrize)
            {
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
                GiveThisPrize = false;
            }
        }
    }
}
