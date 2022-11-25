using UnityEngine;
using UnityEngine.UI;
using System;

namespace Localization
{
    public class LocalizationChangerManager : MonoBehaviour
    {
        public static event Action LocalizationChanged;
        public Text CurrentLanguageIcon;
        public Text LastLanguageIcon;
        public void SwitchLanguage()
        {
            LocalizationChanged.Invoke();
            LastLanguageIcon.color = new Color(1, 1, 1, 1);
            CurrentLanguageIcon.color = new Color(0.8862745f, 0.4313726f, 0.6352941f, 1);
            LastLanguageIcon = CurrentLanguageIcon;
        }
    }
}
