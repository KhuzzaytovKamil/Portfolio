using UnityEngine;
using Finish.LoseSystem;
using Finish.WinSystem;
using Goods;
using Pipe;

namespace ClassicLvlGenerator
{
    public class ClassicLvlSettingsManager : MonoBehaviour
    {
        [SerializeField]
        ActivateTruePipelineController TruePipelineActivator;
        public LoseManager LoseScript;
        public WinManager WinScript;
        public int LvlNumber;
        public int TimeForLvl;
        public int ForOneStar;
        public int ForTwoStars;
        public int ForTreeStars;
        public int MoneyForTheFirstStar;
        public int MoneyForTheSecondStar;
        public int MoneyForTheThirdStar;
        public int EliteMoneyForTheThirdStar;
        public void SetInfoForPipelineBank(InfoForPipelineBank InfoForPipeline) => 
            TruePipelineActivator.SetInfoForPipelineBank(InfoForPipeline);
    }
}