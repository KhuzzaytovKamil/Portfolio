using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/EliteMoneyGoodsManager")]
    public class EliteMoneyGoodsManager : ScriptableObject
    {
        public Sprite SpriteForADSGoods;
        public int ADSNumberEliteMoney;
    }
}
