using UnityEngine;
using ScriptableObjects.Economy;
using UnityEngine.SceneManagement;

namespace Main
{
    public class ResetProgressController : MonoBehaviour
    {
        [SerializeField]
        ColorsManager ColorsManager;
        int LvlNumber;
        int ColorNumber;
        public void ResetProgress()
        {
            for (LvlNumber = PlayerPrefs.GetInt("LastCompletedLvlNumber"); LvlNumber > 0; LvlNumber--)
            {
                PlayerPrefs.SetInt("FalseNextBlockInLvl" + LvlNumber, 0);
                PlayerPrefs.SetInt("StarsInLvl" + LvlNumber, 0);
            }
            for (ColorNumber = ColorsManager.ColorNumber - 1; ColorNumber > 0; ColorNumber--)
            {
                ColorsManager.UsedStatus[ColorNumber] = false;
                ColorsManager.BuyedStatus[ColorNumber] = false;
            }
            ColorsManager.UsedStatus[0] = true;
            PlayerPrefs.SetInt("money", 0);
            PlayerPrefs.SetInt("EliteMoney", 0);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
