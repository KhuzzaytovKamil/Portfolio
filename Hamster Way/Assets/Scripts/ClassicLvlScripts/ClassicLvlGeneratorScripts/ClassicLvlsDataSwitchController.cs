using UnityEngine;
using ScriptableObjects.LvlsManager;

namespace ClassicLvlGenerator
{
    public class ClassicLvlsDataSwitchController : MonoBehaviour
    {
        [SerializeField]
        ClassicLvlsManager ClassicLvlsManager;
        [SerializeField]
        int LvlNumber;
        [SerializeField]
        GameObject Pipeline;
        [Header("Time")]
        [SerializeField]
        int TimeForLvl; 
        [SerializeField]
        int TimeForOneStar;
        [SerializeField]
        int TimeForTwoStars;
        [SerializeField]
        int TimeForTreeStars;
        [Header("Money")]
        [SerializeField]
        int MoneyForTheFirstStar;
        [SerializeField]
        int MoneyForTheSecondStar;
        [SerializeField]
        int MoneyForTheThirdStar;
        [SerializeField]
        int EliteMoneyForTheThirdStar;
        public void SetData()
        {
            ClassicLvlsManager.Pipeline[LvlNumber].name = "EmptyName";
            ClassicLvlsManager.Pipeline[LvlNumber] = Pipeline;
            ClassicLvlsManager.Pipeline[LvlNumber].name = "ClassicPipelineForLvl_" + LvlNumber.ToString();
            ClassicLvlsManager.TimeForLvl[LvlNumber] = TimeForLvl;
            ClassicLvlsManager.TimeForOneStar[LvlNumber] = TimeForOneStar;
            ClassicLvlsManager.TimeForTwoStars[LvlNumber] = TimeForTwoStars;
            ClassicLvlsManager.TimeForTreeStars[LvlNumber] = TimeForTreeStars;
            ClassicLvlsManager.MoneyForTheFirstStar[LvlNumber] = MoneyForTheFirstStar;
            ClassicLvlsManager.MoneyForTheSecondStar[LvlNumber] = MoneyForTheSecondStar;
            ClassicLvlsManager.MoneyForTheThirdStar[LvlNumber] = MoneyForTheThirdStar;
            ClassicLvlsManager.EliteMoneyForTheThirdStar[LvlNumber] = EliteMoneyForTheThirdStar;
        }
        public void GetData()
        {
            Pipeline = ClassicLvlsManager.Pipeline[LvlNumber];
            TimeForLvl = ClassicLvlsManager.TimeForLvl[LvlNumber];
            TimeForOneStar = ClassicLvlsManager.TimeForOneStar[LvlNumber];
            TimeForTwoStars = ClassicLvlsManager.TimeForTwoStars[LvlNumber];
            TimeForTreeStars = ClassicLvlsManager.TimeForTreeStars[LvlNumber];
            MoneyForTheFirstStar = ClassicLvlsManager.MoneyForTheFirstStar[LvlNumber];
            MoneyForTheSecondStar = ClassicLvlsManager.MoneyForTheSecondStar[LvlNumber];
            MoneyForTheThirdStar = ClassicLvlsManager.MoneyForTheThirdStar[LvlNumber];
            EliteMoneyForTheThirdStar = ClassicLvlsManager.EliteMoneyForTheThirdStar[LvlNumber];
        }
    }
}
