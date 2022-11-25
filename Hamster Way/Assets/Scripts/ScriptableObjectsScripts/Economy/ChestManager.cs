using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/ChestManager")]
    public class ChestManager : ScriptableObject
    {
        [Header("LowChest")]
        public int LowChestPriceInEliteMoney;
        public int MinNumberMoneyInLowChest;
        public int MaxNumberMoneyInLowChest;
        public int MinNumberEliteMoneyInLowChest;
        public int MaxNumberEliteMoneyInLowChest;
        public int MinNumberPrizeInLowChest;
        public int MaxNumberPrizeInLowChest;
        public Sprite LowChestSprite;
        public Sprite OpenedLowChestSprite;
        [Header("MiddleChest")]
        public int MiddleChestPriceInEliteMoney;
        public int MinNumberMoneyInMiddleChest;
        public int MaxNumberMoneyInMiddleChest;
        public int MinNumberEliteMoneyInMiddleChest;
        public int MaxNumberEliteMoneyInMiddleChest;
        public int MinNumberPrizeInMiddleChest;
        public int MaxNumberPrizeInMiddleChest;
        public Sprite MiddleChestSprite;
        public Sprite OpenedMiddleChestSprite;
        [Header("HighChest")]
        public int HighChestPriceInEliteMoney;
        public int MinNumberMoneyInHighChest;
        public int MaxNumberMoneyInHighChest;
        public int MinNumberEliteMoneyInHighChest;
        public int MaxNumberEliteMoneyInHighChest;
        public int MinNumberPrizeInHighChest;
        public int MaxNumberPrizeInHighChest;
        public Sprite HighChestSprite;
        public Sprite OpenedHighChestSprite;
        [Space(50)]
        public int[] MaxPrizeValueInHearts;
    }
}
