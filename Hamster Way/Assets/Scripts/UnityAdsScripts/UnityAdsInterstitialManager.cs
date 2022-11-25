using UnityEngine;
using UnityEngine.Advertisements;

namespace UnityAds
{
    public class UnityAdsInterstitialManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        [SerializeField]
        string AndroidAdID = "Interstitial_Android";
        [SerializeField]
        string iOSAdID = "Interstitial_iOS";
        string CurrentAdID;
        void Start()
        {
#if UNITY_IOS
            CurrentAdID = iOSAdID;
#endif
#if UNITY_ANDROID
            CurrentAdID = AndroidAdID;
#endif
            LoadAd();
        }

        void LoadAd() => Advertisement.Load(CurrentAdID, this);

        public void ShowAd() => Advertisement.Show(CurrentAdID, this);

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }

        public void OnUnityAdsShowStart(string placementId) { }

        public void OnUnityAdsShowClick(string placementId) { }


        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) => LoadAd();
        
        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }

        public void OnUnityAdsAdLoaded(string placementId) { }
    }
}