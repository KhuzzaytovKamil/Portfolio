using UnityEngine;
using UnityEngine.UI;
using System;
using ScriptableObjects.Economy;

namespace Goods
{
    public class GetMoreTimeController : MonoBehaviour
    {
        [SerializeField]
        GoodsInfoBank GoodsInfoBank;
        [SerializeField]
        Text Price;
        public static event Action UsedTime;

        void Start() => Price.text = GoodsInfoBank.GetTimePrice.ToString();
        
        public void UseGoods()
        {
            if (PlayerPrefs.GetInt("money") >= GoodsInfoBank.GetTimePrice)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - GoodsInfoBank.GetTimePrice);
                UsedTime.Invoke();
            }
        }
    }
}

