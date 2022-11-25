using UnityEngine;

namespace ScriptableObjects.LvlsManager
{
    [CreateAssetMenu(menuName = "LvlsManager/ClassicLvlsManager")]
    public class ClassicLvlsManager : ScriptableObject
    {
        public int LvlNumber;
        public GameObject LvlReference;
        public GameObject[] Pipeline;
        [Header("Time")]
        public int[] TimeForLvl; 
        public int[] TimeForOneStar; 
        public int[] TimeForTwoStars; 
        public int[] TimeForTreeStars;
        [Header("Money")]
        public int[] MoneyForTheFirstStar;
        public int[] MoneyForTheSecondStar;
        public int[] MoneyForTheThirdStar;
        public int[] EliteMoneyForTheThirdStar;

        public int CurrentLastLvlNumber;
    }
}
