using UnityEngine;
using ScriptableObjects.Economy;
using UnityEngine.UI;
using Scroll;
using UnityEngine.SceneManagement;

namespace EatSystem
{
    public class FoodGoodsController : MonoBehaviour
    {
        [SerializeField]
        int Number;
        [SerializeField]
        FoodManager DataManager;
        [SerializeField]
        Text Price;
        [SerializeField]
        Image Image;
        [SerializeField]
        OpenSamePlaceInScroll OpenSamePlaceInScrollController;
        [SerializeField]
        ShowFoodController ShowFoodController;
        [Header("DataForInfoScreen:")]
        [SerializeField]
        Image FoodImageInInfoScreen;
        [SerializeField]
        GameObject InfoScreen;
        [SerializeField]
        GameObject EffctInfo;
        [SerializeField]
        Text SatietyText;
        [SerializeField]
        Text EffctFactorText;
        [SerializeField]
        GameObject EffctMoneyImage;
        [SerializeField]
        GameObject EffctEliteMoneyImage;
        [SerializeField]
        GameObject EffctHeartsImage;
        void Start()
        {
            Image.sprite = DataManager.Sprite[Number];
            Price.text = DataManager.Price[Number].ToString();
        }

        public void BuyGoods()
        {
            if (DataManager.Price[Number] <= PlayerPrefs.GetInt("Hearts"))
            {
                PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") - DataManager.Price[Number]);
                PlayerPrefs.SetInt("Current" + DataManager.FoodsName[Number] + "Number", PlayerPrefs.GetInt("Current" + DataManager.FoodsName[Number] + "Number") + 1);
                ShowFoodController.UpdateCurrentFoodsNumber(Number);
            }
            else
            {
                
            }
        }

        public void OpenInfoScreen()
        {
            FoodImageInInfoScreen.sprite = DataManager.Sprite[Number];

            EffctInfo.SetActive(false);
            EffctMoneyImage.SetActive(false);
            EffctHeartsImage.SetActive(false);
            EffctEliteMoneyImage.SetActive(false);

            SatietyText.text = (DataManager.DestroyHungryForEat[Number] * 100).ToString() + "%";

            if (DataManager.EffctMoneyFactor[Number] > 0)
            {
                EffctFactorText.text = (DataManager.EffctMoneyFactor[Number] * 100).ToString() + "%";
                EffctInfo.SetActive(true);
                EffctMoneyImage.SetActive(true);
            }
            else if (DataManager.EffctHeartsFactor[Number] > 0)
            {
                EffctFactorText.text = (DataManager.EffctHeartsFactor[Number] * 100).ToString() + "%";
                EffctInfo.SetActive(true);
                EffctHeartsImage.SetActive(true);
            }
            else if (DataManager.EffctEliteMoneyFactor[Number] > 0)
            {
                EffctFactorText.text = (DataManager.EffctEliteMoneyFactor[Number] * 100).ToString() + "%";
                EffctInfo.SetActive(true);
                EffctEliteMoneyImage.SetActive(true);
            }
            
            InfoScreen.SetActive(true);
        }
    }
}
