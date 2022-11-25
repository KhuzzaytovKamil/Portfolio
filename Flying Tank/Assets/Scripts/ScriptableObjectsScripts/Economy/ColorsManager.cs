using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/ColorsManager")]
    public class ColorsManager : ScriptableObject
    {
        public int ColorNumber;
        public Color[] Color;
        public Material[] ColorMaterial;
        public int[] Price;
        public bool[] UsedStatus;
        public bool[] BuyedStatus;
    }
}
