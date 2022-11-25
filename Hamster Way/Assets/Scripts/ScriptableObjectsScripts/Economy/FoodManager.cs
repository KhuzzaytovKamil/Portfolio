using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/FoodManager")]
    public class FoodManager : ScriptableObject
    {
        [Header("MainSettings:")]
        public int TypeNumber;
        public Sprite[] Sprite;
        public int[] Price;
        public string[] FoodsName;
        public float[] DestroyHungryForEat;
        [Header("EffctSettings:")]
        public float[] EffctMoneyFactor;
        public float[] EffctHeartsFactor;
        public float[] EffctEliteMoneyFactor;
        public float[] EffctTimeInSeconds;
    }
}