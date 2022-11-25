using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/PrizeManager")]
    public class PrizeManager : ScriptableObject
    {
        public int LastPrizeNumber;
        public int HappinessPointNumberForPrize;
        public int HappinessPointInStart;
        public int MaxHappinessPoint;
        public float ExtraHappinessPointInSecond;
        public Sprite LowChestTexture;
        public Sprite MiddleChestTexture;
        public Sprite HighChestTexture;
        public Sprite MoneyTexture;
        public Sprite EliteMoneyTexture;
    }
}
