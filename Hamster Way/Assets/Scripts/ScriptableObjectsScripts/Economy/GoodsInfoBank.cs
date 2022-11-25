using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/GoodsInfoBank")]
    public class GoodsInfoBank : ScriptableObject
    {
        [Header("ClassicLvl_GetTime")]
        public int GetTimePrice; 
        public int TimeNumberInSeconds;
        [Header("ClassicLvl_TruePipeline")]
        public int[] TruePipelinePrice; 
        public float TruePipelineOnSeconds;
        [Header("ClassicLvl_Engineer")]
        public int[] EngineerPrice;
        [Space(30)]
        [Header("MatchingCards_GetOpening")]
        public int GetOpeningPrice;
        public int OpeningNumber;
    }
}
