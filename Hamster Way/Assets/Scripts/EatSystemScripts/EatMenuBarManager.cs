using UnityEngine;
using UnityEngine.UI;

namespace EatSystem
{
    public class EatMenuBarManager : MonoBehaviour
    {
        [SerializeField]
        GameObject CenterScreenPoint;
        [SerializeField]
        GameObject EatSystemEducation;
        [SerializeField]
        GameObject StartPositionPoint;
        [SerializeField]
        GameObject EatBar;
        [SerializeField]
        EatBarType BarType = EatBarType.Closeing;
        float EatBarTruePosition;
        float Amplitude;
        float BarOpeningTruePosition;
        float BarCloseingTruePosition;
        [SerializeField]
        float TypeChangeTime;
        [Header("Bars:")]
        [SerializeField]
        GameObject MiniBarSystem;
        [SerializeField]
        Image MainBar;
        [SerializeField]
        Image MiniBar;
        [SerializeField]
        GameObject EatIcon_2;
        [SerializeField]
        GameObject FoodNumberInfoBlock;
        Vector3 StartFoodNumberInfoBlockPosition;

        enum EatBarType { Opening, Closeing }

        void Start()
        {
            if (PlayerPrefs.GetInt("EducationСompleted") == 1)
                EatSystemEducation.SetActive(false);
            Amplitude = StartPositionPoint.transform.position.x - CenterScreenPoint.transform.position.x;
            BarOpeningTruePosition = EatBar.transform.position.x - Amplitude;
            BarCloseingTruePosition = EatBar.transform.position.x;
            StartFoodNumberInfoBlockPosition = FoodNumberInfoBlock.transform.position;
            EatBarTruePosition = BarCloseingTruePosition;
        }
        public void ClickToEatBar()
        {
            if (BarType == EatBarType.Closeing)
            {
                EatBarTruePosition = BarOpeningTruePosition;
                MiniBarSystem.SetActive(false);
                BarType = EatBarType.Opening;
                EatBar.transform.position -= new Vector3(1, 0, 0) * (StartPositionPoint.transform.position.x - CenterScreenPoint.transform.position.x);
                EatIcon_2.SetActive(true);
            }
            else
            {
                EatBarTruePosition = BarCloseingTruePosition;
                MiniBarSystem.SetActive(true);
                BarType = EatBarType.Closeing;
                EatBar.transform.position += new Vector3(1, 0, 0) * (StartPositionPoint.transform.position.x - CenterScreenPoint.transform.position.x);
                EatIcon_2.SetActive(false);
                FoodNumberInfoBlock.transform.position = StartFoodNumberInfoBlockPosition;
            }
        }

        void Update()
        {
            MainBar.fillAmount = 1 - PlayerPrefs.GetFloat("CurrentHungry");
            MiniBar.fillAmount = 1 - PlayerPrefs.GetFloat("CurrentHungry");
        }

        public void SetActiveEducationСompleted() => PlayerPrefs.SetInt("EducationСompleted", 1);
    }
}