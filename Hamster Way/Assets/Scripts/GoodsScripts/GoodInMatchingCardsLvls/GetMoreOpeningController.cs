using UnityEngine;
using UnityEngine.UI;
using System;
using ScriptableObjects.Economy;

namespace Goods
{
    public class GetMoreOpeningController : MonoBehaviour
    {
        [SerializeField]
        GoodsInfoBank GoodsInfoBank;
        [SerializeField]
        Text Price;
        public static event Action UsedOpening;

        void Start() => Price.text = GoodsInfoBank.GetOpeningPrice.ToString();
        
        public void UseGoods()
        {
            if (PlayerPrefs.GetInt("money") >= GoodsInfoBank.GetOpeningPrice)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - GoodsInfoBank.GetOpeningPrice);
                UsedOpening.Invoke();
            }
        }
    }
}