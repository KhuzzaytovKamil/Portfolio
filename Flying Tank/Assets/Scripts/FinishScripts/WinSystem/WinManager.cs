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

        void OnDestroy() => Win -= CreateWinWindow;

        void OnDisable() => Win -= CreateWinWindow;

        void OnEnable() => Win += CreateWinWindow;

        void OnCollisionEnter() => Win.Invoke();

        public void WinGame() => Win.Invoke();

        void CreateWinWindow()
        {
            if (WinWindow != null)
                WinWindow.SetActive(true);
        }
    }
}
