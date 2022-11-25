using UnityEngine;
using System;

namespace Finish.WinSystem
{
    public class WinManager : MonoBehaviour
    {
        public static event Action Win;
        [SerializeField]
        GameObject WinWindow;
        void Start() => Win += CreateWinWindow;
        
        void OnDestroy()
        {
            Win -= CreateWinWindow;
            Win -= SetWinTime;
        }
        void OnDisable()
        {
            Win -= CreateWinWindow;
            Win -= SetWinTime;
        }
        void OnEnable()
        {
            Win += CreateWinWindow;
            Win += SetWinTime;
        }
        public void WinGame() => Win.Invoke();
        
        void SetWinTime() => 
            PlayerPrefs.SetString("LastWinTime", System.DateTime.UtcNow.ToString("u", System.Globalization.CultureInfo.InvariantCulture));
        
        void CreateWinWindow()
        {
            if (WinWindow != null)
                WinWindow.SetActive(true);
        }
    }
}
