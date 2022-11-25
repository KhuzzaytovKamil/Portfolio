using UnityEngine;
using LvlGenerator;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class LvlSwitchSceneController : MonoBehaviour
    {
        [SerializeField]
        PlatformGeneratorManager LvlManager;
        public void RestartLvl() => SceneManager.LoadScene("Lvl");
        
        public void NextLvl()
        {
            PlayerPrefs.SetInt("LvlNumber", LvlManager.LvlNumber + 1);
            SceneManager.LoadScene("Lvl");
        }
    }
}
