using UnityEngine;
using UnityEngine.Advertisements;

namespace UnityAds
{
    public class UnityAdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        [SerializeField]
        string AndroidGameID;
        [SerializeField]
        string iOSGameID;
        string CurrentGameID;
        [SerializeField]
        bool TestMode = true;
        void Start() => InitializeAds();

        void InitializeAds()
        {
#if UNITY_IOS
            CurrentGameID = iOSGameID;
#endif
#if UNITY_ANDROID
            CurrentGameID = AndroidGameID;
#endif
            Advertisement.Initialize(CurrentGameID, TestMode, this);
        }

        public void OnInitializationComplete() { }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message) { }
    }
}