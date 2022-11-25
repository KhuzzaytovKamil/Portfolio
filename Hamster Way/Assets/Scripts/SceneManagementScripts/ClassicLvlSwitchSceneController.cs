using UnityEngine;
using ClassicLvlGenerator;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class ClassicLvlSwitchSceneController : MonoBehaviour
    {
        [SerializeField]
        ClassicLvlSettingsManager LvlManager;
        public void RestartLvl() => SceneManager.LoadScene("ClassicLvl");
        
        public void NextLvl()
        {
            PlayerPrefs.SetInt("ClassicLvlNumber", LvlManager.LvlNumber + 1);
            SceneManager.LoadScene("ClassicLvl");
        }
    }
}
