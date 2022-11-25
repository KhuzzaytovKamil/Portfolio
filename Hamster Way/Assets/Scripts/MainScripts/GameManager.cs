using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public class GameManager : MonoBehaviour
    {
        public void OpenWindow(GameObject Window) => Window.SetActive(true);

        public void CloseWindow(GameObject Window) => Window.SetActive(false);

        public void SwichSceneTo(string SceneName) => SceneManager.LoadScene(SceneName);

        public static string SecondsNumberToClassicTime(int TimeInSecondNumber)
        {
            if (TimeInSecondNumber < 10)
                return ("00:00:0" + TimeInSecondNumber.ToString());
            else if (TimeInSecondNumber < 60)
                return ("00:00:" + TimeInSecondNumber.ToString());
            else if (TimeInSecondNumber < (10 * 60))
            {
                float SecondsNumber;
                float MinutesNumber;
                MinutesNumber = Mathf.Round(TimeInSecondNumber / 60);
                if ((MinutesNumber * 60) > TimeInSecondNumber)
                    MinutesNumber--;
                SecondsNumber = TimeInSecondNumber - (MinutesNumber * 60);
                if (SecondsNumber < 10)
                    return ("00:0" + MinutesNumber.ToString() + ":0" + SecondsNumber.ToString());
                else
                    return ("00:0" + MinutesNumber.ToString() + ":" + SecondsNumber.ToString());
            }
            else if (TimeInSecondNumber < (60 * 60))
            {
                float SecondsNumber;
                float MinutesNumber;
                MinutesNumber = Mathf.Round(TimeInSecondNumber / 60);
                if ((MinutesNumber * 60) > TimeInSecondNumber)
                    MinutesNumber--;
                SecondsNumber = TimeInSecondNumber - (MinutesNumber * 60);
                if (SecondsNumber < 10)
                    return ("00:" + MinutesNumber.ToString() + ":0" + SecondsNumber.ToString());
                else
                    return ("00:" + MinutesNumber.ToString() + ":" + SecondsNumber.ToString());
            }
            else if (TimeInSecondNumber < (10 * 60 * 60))
            {
                float SecondsNumber;
                float MinutesNumber;
                float HoursNumber;
                HoursNumber = Mathf.Round(TimeInSecondNumber / (60 * 60));
                MinutesNumber = Mathf.Round((TimeInSecondNumber - (HoursNumber * (60 * 60))) / 60);
                if ((HoursNumber * (60 * 60)) > TimeInSecondNumber)
                    HoursNumber--;
                if (((MinutesNumber * 60) + (HoursNumber * (60 * 60))) > TimeInSecondNumber)
                    MinutesNumber--;
                SecondsNumber = TimeInSecondNumber - ((HoursNumber * (60 * 60)) + (MinutesNumber * 60));
                if (MinutesNumber < 10)
                {
                    if (SecondsNumber < 10)
                        return ("0" + HoursNumber.ToString() + ":0" + MinutesNumber.ToString() + ":0" + SecondsNumber.ToString());
                    else
                        return ("0" + HoursNumber.ToString() + ":0" + MinutesNumber.ToString() + ":" + SecondsNumber.ToString());
                }
                else
                {
                    if (SecondsNumber < 10)
                        return ("0" + HoursNumber.ToString() + ":" + MinutesNumber.ToString() + ":0" + SecondsNumber.ToString());
                    else
                        return ("0" + HoursNumber.ToString() + ":" + MinutesNumber.ToString() + ":" + SecondsNumber.ToString());
                }
            }
            else
            {
                float SecondsNumber;
                float MinutesNumber;
                float HoursNumber;
                HoursNumber = Mathf.Round(TimeInSecondNumber / (60 * 60));
                MinutesNumber = Mathf.Round((TimeInSecondNumber - (HoursNumber * (60 * 60))) / 60);
                if ((HoursNumber * (60 * 60)) > TimeInSecondNumber)
                    HoursNumber--;
                if (((MinutesNumber * 60) + (HoursNumber * (60 * 60))) > TimeInSecondNumber)
                    MinutesNumber--;
                SecondsNumber = TimeInSecondNumber - ((HoursNumber * (60 * 60)) + (MinutesNumber * 60));
                if (MinutesNumber < 10)
                {
                    if (SecondsNumber < 10)
                        return (HoursNumber.ToString() + ":0" + MinutesNumber.ToString() + ":0" + SecondsNumber.ToString());
                    else
                        return (HoursNumber.ToString() + ":0" + MinutesNumber.ToString() + ":" + SecondsNumber.ToString());
                }
                else
                {
                    if (SecondsNumber < 10)
                        return (HoursNumber.ToString() + ":" + MinutesNumber.ToString() + ":0" + SecondsNumber.ToString());
                    else
                        return (HoursNumber.ToString() + ":" + MinutesNumber.ToString() + ":" + SecondsNumber.ToString());
                }
            }
        }
    }
}