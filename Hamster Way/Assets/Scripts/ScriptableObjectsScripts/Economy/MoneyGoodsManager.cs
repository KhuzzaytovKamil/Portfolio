using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/MoneyGoodsManager")]
    public class MoneyGoodsManager : ScriptableObject
    {
        public Sprite[] SpriteForThisGoods;
        public int[] NumberMoney;
        public int[] PriceInEliteMoney;
        public Sprite SpriteForADSGoods;
        public int ADSNumberMoney;
    }
}
