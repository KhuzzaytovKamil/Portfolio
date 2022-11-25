using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Economy;

namespace PrizeSystem
{
    public class EntityPrizeController : MonoBehaviour
    {
        [SerializeField]
        int PrizeNumber;
        [SerializeField]
        PrizeManager PrizeManager;
        [SerializeField]
        Image PrizeIcon;
        [SerializeField]
        GameObject VisualBlock;
        [Header("Prize Type:")]
        public int MoneyNumber;
        public int EliteMoneyNumber;
        public bool LowChestPrize;
        public bool MiddleChestPrize;
        public bool HighChestPrize;
        void Start()
        {
            SetPrizeType();
            if (MoneyNumber != 0)
                PrizeIcon.sprite = PrizeManager.MoneyTexture;
            else if (EliteMoneyNumber != 0)
                PrizeIcon.sprite = PrizeManager.EliteMoneyTexture;
            else if (LowChestPrize)
                PrizeIcon.sprite = PrizeManager.LowChestTexture;
            else if (MiddleChestPrize)
                PrizeIcon.sprite = PrizeManager.MiddleChestTexture;
            else if (HighChestPrize)
                PrizeIcon.sprite = PrizeManager.HighChestTexture;
            CurrentPrizeController.PrizeIsGot += SetPrizeType;
        }
        void OnDestroy() => CurrentPrizeController.PrizeIsGot -= SetPrizeType;
        
        void OnDisable() => CurrentPrizeController.PrizeIsGot -= SetPrizeType;
        
        void OnEnable() => CurrentPrizeController.PrizeIsGot += SetPrizeType;
        
        void SetPrizeType()
        {
            if (PrizeNumber != PlayerPrefs.GetInt("CurrentPrize"))
                gameObject.transform.localScale = new Vector3(0.9f, 0.9f, 0);
            else
                gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 0);
            if (PrizeNumber < PlayerPrefs.GetInt("CurrentPrize"))
                VisualBlock.SetActive(true);
        }
    }    
}

