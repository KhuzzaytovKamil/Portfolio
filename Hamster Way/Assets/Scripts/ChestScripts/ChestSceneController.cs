using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ScriptableObjects.Economy;
using Audio;

namespace Chest
{
    public class ChestSceneController : MonoBehaviour
    {
        int CurrentPrizeNumber = -2;
        [SerializeField]
        GameObject PrizeParent;
        [SerializeField]
        ChestManager ChestInfoBank;
        [SerializeField]
        FoodManager FoodManager;
        bool ChestIsOpened = false;
        [SerializeField]
        Image PrizeImage;
        [SerializeField]
        Image ChestImage;
        [SerializeField]
        Text PrizeText;
        int PrizeNumberInChest;
        int MoneyInChest;
        int EliteMoneyInChest;
        [SerializeField]
        Sprite MoneySprite;
        [SerializeField]
        Sprite EliteMoneySprite;
        [SerializeField]
        AudioSource OpenChestAudio;
        int NumberFood;
        int FoodPrizeNumber;
        void Start()
        {
            if (PlayerPrefs.GetInt("Stars") == 1)
            {
                PrizeNumberInChest = Random.Range(ChestInfoBank.MinNumberPrizeInLowChest, ChestInfoBank.MaxNumberPrizeInLowChest + 1);
                MoneyInChest = Random.Range(ChestInfoBank.MinNumberMoneyInLowChest, ChestInfoBank.MaxNumberMoneyInLowChest + 1);
                EliteMoneyInChest = Random.Range(ChestInfoBank.MinNumberEliteMoneyInLowChest, ChestInfoBank.MaxNumberEliteMoneyInLowChest + 1);
                ChestImage.sprite = ChestInfoBank.LowChestSprite;
            }
            else if (PlayerPrefs.GetInt("Stars") == 2)
            {
                PrizeNumberInChest = Random.Range(ChestInfoBank.MinNumberPrizeInMiddleChest, ChestInfoBank.MaxNumberPrizeInMiddleChest + 1);
                MoneyInChest = Random.Range(ChestInfoBank.MinNumberMoneyInMiddleChest, ChestInfoBank.MaxNumberMoneyInMiddleChest + 1);
                EliteMoneyInChest = Random.Range(ChestInfoBank.MinNumberEliteMoneyInMiddleChest, ChestInfoBank.MaxNumberEliteMoneyInMiddleChest + 1);
                ChestImage.sprite = ChestInfoBank.MiddleChestSprite;
            }
            else if (PlayerPrefs.GetInt("Stars") == 3)
            {
                PrizeNumberInChest = Random.Range(ChestInfoBank.MinNumberPrizeInHighChest, ChestInfoBank.MaxNumberPrizeInHighChest + 1);
                MoneyInChest = Random.Range(ChestInfoBank.MinNumberMoneyInHighChest, ChestInfoBank.MaxNumberMoneyInHighChest + 1);
                EliteMoneyInChest = Random.Range(ChestInfoBank.MinNumberEliteMoneyInHighChest, ChestInfoBank.MaxNumberEliteMoneyInHighChest + 1);
                ChestImage.sprite = ChestInfoBank.HighChestSprite;
            }
        }
        public void Click()
        {
            if (ChestIsOpened != true)
            {
                ChestIsOpened = true;
                if (PlayerPrefs.GetInt("Stars") == 1)
                    ChestImage.sprite = ChestInfoBank.OpenedLowChestSprite;
                else if (PlayerPrefs.GetInt("Stars") == 2)
                    ChestImage.sprite = ChestInfoBank.OpenedMiddleChestSprite;
                else if (PlayerPrefs.GetInt("Stars") == 3)
                    ChestImage.sprite = ChestInfoBank.OpenedHighChestSprite;
            }

            GivePrize();
        }

        void GivePrize()
        {
            if (CurrentPrizeNumber >= PrizeNumberInChest)
                SceneManager.LoadScene("MainMenu");
            else
            {
                if (CurrentPrizeNumber == -2)
                {
                    PrizeImage.sprite = MoneySprite;
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + MoneyInChest);
                    PrizeText.text = MoneyInChest.ToString();
                }
                else if (CurrentPrizeNumber == -1)
                {
                    PrizeImage.sprite = EliteMoneySprite;
                    PlayerPrefs.SetInt("EliteMoney", PlayerPrefs.GetInt("EliteMoney") + EliteMoneyInChest);
                    PrizeText.text = EliteMoneyInChest.ToString();
                }
                else
                {
                    NumberFood = Random.Range(0, FoodManager.TypeNumber);
                    while (true)
                    {
                        if (ChestInfoBank.MaxPrizeValueInHearts[CurrentPrizeNumber] > FoodManager.Price[NumberFood])
                        {
                            FoodPrizeNumber = Random.Range(1, (Mathf.CeilToInt(ChestInfoBank.MaxPrizeValueInHearts[CurrentPrizeNumber] / FoodManager.Price[NumberFood]) + Random.Range(0, 3)));
                            break;
                        }
                        else
                            NumberFood = Random.Range(0, FoodManager.TypeNumber);
                    }

                    PrizeImage.sprite = FoodManager.Sprite[NumberFood];
                    PlayerPrefs.SetInt("Current" + FoodManager.FoodsName[NumberFood] + "Number", PlayerPrefs.GetInt("Current" + FoodManager.FoodsName[NumberFood] + "Number") + FoodPrizeNumber);
                    PrizeText.text = FoodPrizeNumber.ToString();
                }

                SoundController.PLAY_THIS_SOUND(OpenChestAudio);
                PrizeParent.SetActive(false);
                PrizeParent.SetActive(true);
                CurrentPrizeNumber++;
            }
        }
        
    }
}
