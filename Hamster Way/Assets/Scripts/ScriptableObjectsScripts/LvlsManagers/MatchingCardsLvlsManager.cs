using UnityEngine;

namespace ScriptableObjects.LvlsManager
{
    [CreateAssetMenu(menuName = "LvlsManager/MatchingCardsLvlsManager")]
    public class MatchingCardsLvlsManager : ScriptableObject
    {
        public int LvlNumber;
        public GameObject[] GameSpace;
        public int[] OpeningForLvl;
        [Space(20)]
        public float EasyFactorForPrize;
        public float MiddleFactorForPrize;
        public float HardFactorForPrize;
        [Space(20)]
        public float EasyFactorForOpening;
        public float MiddleFactorForOpening;
        public float HardFactorForOpening;

        [Space(35)]

        public float FactorForOneHeartsPack;
        public float FactorForTwoHeartsPacks;
        public float FactorForTreeHeartsPacks;
        [Space(20)]
        public float PrizeFactorForEasy;
        public float PrizeFactorForMiddle;
        public float PrizeFactorForHard;

        [Space(35)]

        public int[] HeartsForTheFirstHeartsPack;
        public int[] HeartsForTheSecondHeartsPack;
        public int[] HeartsForTheThirdHeartsPack;
    }
}
