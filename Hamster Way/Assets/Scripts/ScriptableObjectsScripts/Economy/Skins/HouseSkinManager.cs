using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/Skins/HouseSkinManager")]
    public class HouseSkinManager : ScriptableObject
    {
        public int SkinNumber;
        public Color[] ColorForBG;
        public Sprite[] SpriteForFG;
        public int[] Price;
    }
}