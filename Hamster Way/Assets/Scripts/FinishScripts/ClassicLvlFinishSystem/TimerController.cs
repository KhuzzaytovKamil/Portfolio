using UnityEngine;
using UnityEngine.UI;
using Finish.LoseSystem;
using Goods;
using ClassicLvlGenerator;
using Finish.WinSystem;
using ScriptableObjects.Economy;

namespace Finish.ClassicLvlFinishSystem
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField]
        ClassicLvlSettingsManager LvlManager;
        float TimeBeforeLose;
        float AllTime;
        [SerializeField]
        LoseManager Lose;
        [SerializeField]
        Image ProgressBar;
        [SerializeField]
        GameObject RightPoint;
        [SerializeField]
        GameObject LeftPoint;
        float ProgressBarWide;
        [SerializeField]
        Sprite EmptyStarSprite;
        [SerializeField]
        Sprite StandardStarSprite;
        [SerializeField]
        GoodsInfoBank GoodsInfoBank;
        [Header("Stars:")]
        float ForTreeStars;
        float ForTwoStars;
        float ForOneStar;
        bool TimeStop = false;
        [SerializeField]
        GameObject TheFirstStar;
        [SerializeField]
        GameObject TheSecondStar;
        [SerializeField]
        GameObject TheThirdStar;
        void Start()
        {
            PlayerPrefs.SetInt("Stars", 0);
            TimeBeforeLose = LvlManager.TimeForLvl;
            ForOneStar = LvlManager.ForOneStar;
            ForTwoStars = LvlManager.ForTwoStars;
            ForTreeStars = LvlManager.ForTreeStars;
            AllTime = TimeBeforeLose;
            ProgressBarWide = RightPoint.transform.position.x - LeftPoint.transform.position.x;
            TheFirstStar.transform.position = new Vector3(LeftPoint.transform.position.x + ((ForOneStar / AllTime) * ProgressBarWide), TheFirstStar.transform.position.y, TheFirstStar.transform.position.z);
            TheSecondStar.transform.position = new Vector3(LeftPoint.transform.position.x + ((ForTwoStars / AllTime) * ProgressBarWide), TheSecondStar.transform.position.y, TheSecondStar.transform.position.z);
            TheThirdStar.transform.position = new Vector3(LeftPoint.transform.position.x + ((ForTreeStars / AllTime) * ProgressBarWide), TheThirdStar.transform.position.y, TheThirdStar.transform.position.z);
            WinManager.Win += WinTime;
            LoseManager.Lose += LoseTime;
            GetMoreTimeController.UsedTime += GetMoreTime;
            GetMoreTimeController.UsedTime += SetStarsAgin;
            PipelineInspector.StartChack += GameStop;
        }
        void OnDisable()
        {
            WinManager.Win -= WinTime;
            LoseManager.Lose -= LoseTime;
            GetMoreTimeController.UsedTime -= GetMoreTime;
            GetMoreTimeController.UsedTime -= SetStarsAgin;
            PipelineInspector.StartChack -= GameStop;
        }
        void OnDestroy()
        {
            WinManager.Win -= WinTime;
            LoseManager.Lose -= LoseTime;
            GetMoreTimeController.UsedTime -= GetMoreTime;
            GetMoreTimeController.UsedTime -= SetStarsAgin;
            PipelineInspector.StartChack -= GameStop;
        }
        void OnEnable()
        {
            WinManager.Win += WinTime;
            LoseManager.Lose += LoseTime;
            GetMoreTimeController.UsedTime += GetMoreTime;
            GetMoreTimeController.UsedTime += SetStarsAgin;
            PipelineInspector.StartChack += GameStop;
        }
        void Update()
        {
            if (TimeStop == false)
            {
                if (TimeBeforeLose == 0 || TimeBeforeLose < 0)
                {
                    PlayerPrefs.SetString("cause", "TimeIsOver");
                    Lose.LoseGame();
                }
                else
                {
                    TimeBeforeLose -= Time.deltaTime;
                    ProgressBar.fillAmount = TimeBeforeLose / AllTime;
                }
                if (TimeBeforeLose < ForOneStar)
                    TheFirstStar.GetComponent<Image>().sprite = EmptyStarSprite;
                else if (TimeBeforeLose < ForTwoStars)
                    TheSecondStar.GetComponent<Image>().sprite = EmptyStarSprite;
                else if (TimeBeforeLose < ForTreeStars)
                    TheThirdStar.GetComponent<Image>().sprite = EmptyStarSprite;
            }
        }
        void WinTime()
        {
            if (TimeBeforeLose >= ForTreeStars)
                PlayerPrefs.SetInt("Stars", 3);
            else if (TimeBeforeLose >= ForTwoStars)
                PlayerPrefs.SetInt("Stars", 2); 
            else if (TimeBeforeLose >= ForOneStar)
                PlayerPrefs.SetInt("Stars", 1); 
            GameStop();
        }
        void GetMoreTime()
        {
            if (TimeBeforeLose + GoodsInfoBank.TimeNumberInSeconds < AllTime)
                TimeBeforeLose = TimeBeforeLose + GoodsInfoBank.TimeNumberInSeconds;
            else
                TimeBeforeLose = AllTime;
        }
        void SetStarsAgin()
        {
            if (TimeBeforeLose >= ForTreeStars)
                TheThirdStar.GetComponent<Image>().sprite = StandardStarSprite;
            if (TimeBeforeLose >= ForTwoStars)
                TheSecondStar.GetComponent<Image>().sprite = StandardStarSprite;
            if (TimeBeforeLose >= ForOneStar)
                TheFirstStar.GetComponent<Image>().sprite = StandardStarSprite;
        }
        void LoseTime() => GameStop();

        public void GameStop() => TimeStop = true;
        
        public void GameContinue() => TimeStop = false;
        
    }
}