using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Economy;

namespace EatSystem
{
    public class ShowFoodController : MonoBehaviour
    {
        [SerializeField]
        int Number;
        [SerializeField]
        FoodManager FoodManager;
        [SerializeField]
        Text NumberText;
        [SerializeField]
        Image NumberImage;
        public void UpdateCurrentFoodsNumber(int Number) => NumberText.text = PlayerPrefs.GetInt("Current" + FoodManager.FoodsName[Number] + "Number").ToString();

        void Start()
        {
            NumberText.text = PlayerPrefs.GetInt("Current" + FoodManager.FoodsName[Number] + "Number").ToString();
            NumberImage.sprite = FoodManager.Sprite[Number];
        }
    }
}
    
