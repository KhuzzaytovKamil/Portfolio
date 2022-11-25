using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/Skins/PlateSkinManager")]
    public class PlateSkinManager : ScriptableObject
    {
        public int PlateSkinNumber;
        public Sprite[] StandardPlateSprite;
        public Sprite[] EmptyPlateSprite;
        public int[] Price;
    }
}