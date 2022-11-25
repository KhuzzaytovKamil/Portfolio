using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
    public class ChangeLocalizeController : MonoBehaviour
    {
        [SerializeField]
        string LanguageName;
        [SerializeField]
        LocalizationChangerManager LocalizationChangerManager;
        void Start()
        {
            if (PlayerPrefs.GetString("Language") == LanguageName)
            {
                LocalizationChangerManager.LastLanguageIcon = gameObject.GetComponent<Text>();
                gameObject.GetComponent<Text>().color = new Color(0.8862745f, 0.4313726f, 0.6352941f, 1);
            }
                
        }
        public void ChangeLanguage()
        {
            PlayerPrefs.SetString("Language", LanguageName);
            LocalizationChangerManager.CurrentLanguageIcon = gameObject.GetComponent<Text>();
            LocalizationChangerManager.SwitchLanguage();
        }
    }
}
