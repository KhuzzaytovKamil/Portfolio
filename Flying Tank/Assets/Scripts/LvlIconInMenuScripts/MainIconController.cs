using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LvlIconInMenu
{
    public class MainIconController : MonoBehaviour
    {
        public int LvlNumber;
        void Start() => gameObject.GetComponentInChildren<Text>().text = LvlNumber.ToString();
        
        public void OpenLvl()
        {
            PlayerPrefs.SetInt("LvlNumber", LvlNumber);
            SceneManager.LoadScene("Lvl");
        }
    }    
}

