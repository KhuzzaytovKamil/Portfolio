using UnityEngine;
using UnityEngine.UI;
using ClassicLvlGenerator;
using ScriptableObjects.Economy;
using Finish.ClassicLvlFinishSystem;

namespace Goods
{
    public class EngineersController : MonoBehaviour
    {
        [SerializeField]
        TimerController TimerController;
        [SerializeField]
        GoodsInfoBank GoodsInfoBank;
        [SerializeField]
        Text Price;
        [SerializeField]
        ClassicLvlSettingsManager LvlManager;  
        [SerializeField]
        GameObject WinWindow;  
        [SerializeField]
        GameObject WinWindowButtons;
        int CurrentPrice;
        void Start()
        {
            if (PlayerPrefs.GetInt("FalseNextBlockInLvl" + LvlManager.LvlNumber) == 1)
                Destroy(gameObject);
            if (LvlManager.LvlNumber < 101)
                CurrentPrice = GoodsInfoBank.EngineerPrice[0];
            else if (LvlManager.LvlNumber < 111)
                CurrentPrice = GoodsInfoBank.EngineerPrice[1];
            else if (LvlManager.LvlNumber < 121)
                CurrentPrice = GoodsInfoBank.EngineerPrice[2];
            else if (LvlManager.LvlNumber < 131)
                CurrentPrice = GoodsInfoBank.EngineerPrice[3];
            else if (LvlManager.LvlNumber < 141)
                CurrentPrice = GoodsInfoBank.EngineerPrice[4];
            else if (LvlManager.LvlNumber < 151)
                CurrentPrice = GoodsInfoBank.EngineerPrice[5];
            else if (LvlManager.LvlNumber < 161)
                CurrentPrice = GoodsInfoBank.EngineerPrice[6];
            else if (LvlManager.LvlNumber < 171)
                CurrentPrice = GoodsInfoBank.EngineerPrice[7];
            else if (LvlManager.LvlNumber < 181)
                CurrentPrice = GoodsInfoBank.EngineerPrice[8];
            else
                CurrentPrice = GoodsInfoBank.EngineerPrice[9];

            Price.text = CurrentPrice.ToString();
        }
        public void UseGoods()
        {
            if (PlayerPrefs.GetInt("money") >= CurrentPrice)
            {
                PlayerPrefs.SetInt("FalseNextBlockInLvl" + LvlManager.LvlNumber, 1);
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - CurrentPrice);
                WinWindow.SetActive(true);
                WinWindowButtons.SetActive(true);
                TimerController.GameStop();
            }
        }
    }
}