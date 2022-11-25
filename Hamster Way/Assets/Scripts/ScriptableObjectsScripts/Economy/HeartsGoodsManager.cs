using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/HeatsGoodsManager")]
    public class HeartsGoodsManager : ScriptableObject
    {
        public Sprite[] SpriteForThisGoods;
        public int[] NumberHeats;
        public int[] PriceInCoins;
        public Sprite SpriteForADSGoods;
        public int ADSNumberHeats;
    }
}