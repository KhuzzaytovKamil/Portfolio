using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/GoodsInfoBank")]
    public class GoodsInfoBank : ScriptableObject
    {
        [Header("Lvl_GetTime")]
        public int GetTimePrice; 
        public int TimeNumberInSeconds;
    }
}