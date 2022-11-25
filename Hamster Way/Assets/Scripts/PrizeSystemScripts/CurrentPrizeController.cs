using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Economy;
using UnityEngine.SceneManagement;
using System;

namespace PrizeSystem
{
    public class CurrentPrizeController : MonoBehaviour
    {
        public static event Action PrizeIsGot;
        [SerializeField]
        GameObject NumberPrize;
        [SerializeField]
        EntityPrizeController[] EntityPrizeControllers;
        [SerializeField]
        Image CurrentPrizeIcon;
        [SerializeField]
        GameObject ProgressOpenPrize;
        [SerializeField]
        PrizeManager PrizeManager;
        void Start()
        {
            SetCurrentPrize();
            PrizeIsGot += SetCurrentPrize;
        }

        void OnDestroy() => PrizeIsGot -= SetCurrentPrize;
        
        void OnDisable() => PrizeIsGot -= SetCurrentPrize;
        
        void OnEnable() => PrizeIsGot += SetCurrentPrize;
        
        void SetCurrentPrize()
        {
            if (EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].MoneyNumber != 0)
            {
                CurrentPrizeIcon.sprite = PrizeManager.MoneyTexture;
                NumberPrize.SetActive(true);
                NumberPrize.GetComponentInChildren<Text>().text = EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].MoneyNumber.ToString();
            }
            else if (EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].EliteMoneyNumber != 0)
            {
                CurrentPrizeIcon.sprite = PrizeManager.EliteMoneyTexture;
                NumberPrize.SetActive(true);
                NumberPrize.GetComponentInChildren<Text>().text = EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].EliteMoneyNumber.ToString();
            }
            else if (EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].LowChestPrize)
            {
                NumberPrize.SetActive(false);
                CurrentPrizeIcon.sprite = PrizeManager.LowChestTexture;
            }
            else if (EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].MiddleChestPrize)
            {
                NumberPrize.SetActive(false);
                CurrentPrizeIcon.sprite = PrizeManager.MiddleChestTexture;
            }
            else if (EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].HighChestPrize)
            {
                NumberPrize.SetActive(false);
                CurrentPrizeIcon.sprite = PrizeManager.HighChestTexture;
            }
        }
        public void GetPrize()
        {
            if (EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].MoneyNumber != 0)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].MoneyNumber);
            }
            else if (EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].EliteMoneyNumber != 0)
            {
                PlayerPrefs.SetInt("EliteMoney", PlayerPrefs.GetInt("EliteMoney") + EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].EliteMoneyNumber);
            }
            else if (EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].LowChestPrize)
            {
                PlayerPrefs.SetInt("Stars", 1);
                SceneManager.LoadScene("ChestScene");
            }
            else if (EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].MiddleChestPrize)
            {
                PlayerPrefs.SetInt("Stars", 2);
                SceneManager.LoadScene("ChestScene");
            }
            else if (EntityPrizeControllers[PlayerPrefs.GetInt("CurrentPrize") - 1].HighChestPrize)
            {
                PlayerPrefs.SetInt("Stars", 3);
                SceneManager.LoadScene("ChestScene");
            }
            if (PrizeManager.LastPrizeNumber > PlayerPrefs.GetInt("CurrentPrize"))
                PlayerPrefs.SetInt("CurrentPrize", PlayerPrefs.GetInt("CurrentPrize") + 1);
            else
                PlayerPrefs.SetInt("CurrentPrize", 1);
            PlayerPrefs.SetFloat("HappinessPoint", PlayerPrefs.GetFloat("HappinessPoint") - PrizeManager.HappinessPointNumberForPrize);
            ProgressOpenPrize.SetActive(true);
            PrizeIsGot.Invoke();
        }
    }    
}

