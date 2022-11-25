using UnityEngine;
using UnityEngine.Advertisements;
using System;

namespace UnityAds
{
    public class UnityAdsRewardedManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        public static event Action UnityAdsShowComplete;
        [SerializeField]
        string AndroidAdID = "Rewarded_Android";
        [SerializeField]
        string iOSAdID = "Rewarded_iOS";
        string CurrentAdID;
        [SerializeField]
        GameObject NoNetworkWindow;
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

        public void OnUnityAdsAdLoaded(string placementId) { }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }

        public void OnUnityAdsShowStart(string placementId) { }

        public void OnUnityAdsShowClick(string placementId) { }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) => UnityAdsShowComplete.Invoke();
    }
}