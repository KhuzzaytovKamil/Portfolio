using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LvlIconInClassicMenu
{
    public class MainIconController : MonoBehaviour
    {
        public int ClassicLvlNumber;
        void Start() => gameObject.GetComponentInChildren<Text>().text = ClassicLvlNumber.ToString();
        
        public void OpenClassicLvl()
        {
            SceneManager.LoadScene("ClassicLvl");
            PlayerPrefs.SetInt("ClassicLvlNumber", ClassicLvlNumber);
        }
    }    
}

