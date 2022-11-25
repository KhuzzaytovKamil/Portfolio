using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Economy;
using Creature.Skins;

namespace EatSystem
{
    public class UsingFoodController : MonoBehaviour
    {
        [SerializeField]
        CretureSkinInMenuController CretureSkinInMenuController;
        [SerializeField]
        ShowFoodController ShowFoodController;
        [SerializeField]
        FoodManager DataManager;
        [SerializeField]
        int Number;
        [SerializeField]
        Image Food;
        void Start() => ShowFoodController.UpdateCurrentFoodsNumber(Number);
        public void UseFood()
        {
            if (PlayerPrefs.GetInt("Current" + DataManager.FoodsName[Number] + "Number") > 0 && PlayerPrefs.GetFloat("CurrentHungry") > 0)
            {
                PlayerPrefs.SetInt("Current" + DataManager.FoodsName[Number] + "Number", PlayerPrefs.GetInt("Current" + DataManager.FoodsName[Number] + "Number") - 1);
                PlayerPrefs.SetFloat("CurrentHungry", PlayerPrefs.GetFloat("CurrentHungry") - DataManager.DestroyHungryForEat[Number]);
                ShowFoodController.UpdateCurrentFoodsNumber(Number);
                Food.sprite = DataManager.Sprite[Number];
                CretureSkinInMenuController.AnimType = "Eat";

                PlayerPrefs.SetFloat("MoneyFactor", DataManager.EffctMoneyFactor[Number]);
                PlayerPrefs.SetFloat("HeartsFactor", DataManager.EffctHeartsFactor[Number]);
                PlayerPrefs.SetFloat("EliteMoneyFactor", DataManager.EffctEliteMoneyFactor[Number]);

                if (PlayerPrefs.GetFloat("MoneyFactor") != 0)
                    PlayerPrefs.SetFloat("MoneyFactorTimeBalance", DataManager.EffctTimeInSeconds[Number]);

                if (PlayerPrefs.GetFloat("HeartsFactor") != 0)
                    PlayerPrefs.SetFloat("HeartsFactorTimeBalance", DataManager.EffctTimeInSeconds[Number]);

                if (PlayerPrefs.GetFloat("EliteMoneyFactor") != 0)
                    PlayerPrefs.SetFloat("EliteMoneyFactorTimeBalance", DataManager.EffctTimeInSeconds[Number]);
            }
        }
    }
}
