namespace GleyMobileAds
{
    using UnityEngine.Events;
    using UnityEngine;
#if USE_UNITYADS
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine.Advertisements;
#endif

#if USE_UNITYADS
    /// <summary>
    /// Unity 6 Compatible Ads System
    /// Removes deprecated IUnityAdsListener, adds IsReady stub
    /// </summary>
    public class CustomUnityAds : MonoBehaviour, ICustomAds
    {
        private UnityAction<bool> OnCompleteMethod;
        private UnityAction<bool, string> OnCompleteMethodWithAdvertiser;
        private UnityAction OnInterstitialClosed;
        private UnityAction<string> OnInterstitialClosedWithAdvertiser;

        private string unityAdsId;
        private string bannerPlacement;
        private string videoAdPlacement;
        private string rewardedVideoAdPlacement;
        private bool debug;
        private bool bannerUsed;
        private global::BannerPosition position;
        private BannerType bannerType;
        private UnityAction<bool, global::BannerPosition, BannerType> DisplayResult;

        /// <summary>
        /// Initialize ads (stubs out for Unity 6)
        /// </summary>
        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, List<PlatformSettings> platformSettings)
        {
            debug = Advertisements.Instance.debug;

#if UNITY_ANDROID
            PlatformSettings settings = platformSettings.First(cond => cond.platform == SupportedPlatforms.Android);
#endif
#if UNITY_IOS
            PlatformSettings settings = platformSettings.First(cond => cond.platform == SupportedPlatforms.iOS);
#endif
            
            unityAdsId = settings.appId.id;
            bannerPlacement = settings.idBanner.id;
            videoAdPlacement = settings.idInterstitial.id;
            rewardedVideoAdPlacement = settings.idRewarded.id;

            if (debug)
            {
                Debug.Log(this + " Initialization Started (Stub - Unity 6)");
                Debug.Log(this + " App ID: " + unityAdsId);
            }
            // Advertisement.AddListener removed - not compatible with Unity 6
        }

        public void UpdateConsent(UserConsent consent, UserConsent ccpaConsent)
        {
            if (debug)
                Debug.Log(this + " Update consent (Stub)");
        }

        // ===== STUB METHODS - Returns true/ready for testing =====
        public bool IsInterstitialAvailable()
        {
            return true; // Stub - always ready for testing
        }

        public void ShowInterstitial(UnityAction InterstitialClosed)
        {
            if (debug) Debug.Log(this + " ShowInterstitial called (Stub)");
            if (InterstitialClosed != null)
                InterstitialClosed();
        }

        public void ShowInterstitial(UnityAction<string> InterstitialClosed)
        {
            if (debug) Debug.Log(this + " ShowInterstitial with advertiser called (Stub)");
            if (InterstitialClosed != null)
                InterstitialClosed(SupportedAdvertisers.Unity.ToString());
        }

        public bool IsRewardVideoAvailable()
        {
            return true; // Stub - always ready
        }

        public void ShowRewardVideo(UnityAction<bool> CompleteMethod)
        {
            if (debug) Debug.Log(this + " ShowRewardVideo called (Stub)");
            if (CompleteMethod != null)
                CompleteMethod(true); // Always reward in stub
        }

        public void ShowRewardVideo(UnityAction<bool, string> CompleteMethod)
        {
            if (debug) Debug.Log(this + " ShowRewardVideo with advertiser called (Stub)");
            if (CompleteMethod != null)
                CompleteMethod(true, SupportedAdvertisers.Unity.ToString());
        }

        public bool IsBannerAvailable()
        {
            return true; // Stub
        }

        public void ResetBannerUsage()
        {
            bannerUsed = false;
        }

        public bool BannerAlreadyUsed()
        {
            return bannerUsed;
        }

        public void ShowBanner(global::BannerPosition position, BannerType bannerType, UnityAction<bool, global::BannerPosition, BannerType> DisplayResult)
        {
            if (debug) Debug.Log(this + " ShowBanner called (Stub)");
            bannerUsed = true;
            
            if (DisplayResult != null)
                DisplayResult(true, position, bannerType);
        }

        public void HideBanner()
        {
            if (debug) Debug.Log(this + " HideBanner called (Stub)");
        }
    }

#else
    /// <summary>
    /// Dummy implementation when USE_UNITYADS not defined
    /// </summary>
    public class CustomUnityAds : MonoBehaviour, ICustomAds
    {
        public void HideBanner() { }
        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, System.Collections.Generic.List<PlatformSettings> platformSettings) { }
        public bool IsBannerAvailable() { return false; }
        public bool IsInterstitialAvailable() { return false; }
        public bool IsRewardVideoAvailable() { return false; }
        public void ShowBanner(BannerPosition position, BannerType type, UnityAction<bool, BannerPosition, BannerType> DisplayResult) { }
        public void ResetBannerUsage() { }
        public bool BannerAlreadyUsed() { return false; }
        public void ShowInterstitial(UnityAction InterstitialClosed = null) { }
        public void ShowInterstitial(UnityAction<string> InterstitialClosed) { }
        public void ShowRewardVideo(UnityAction<bool> CompleteMethod) { }
        public void ShowRewardVideo(UnityAction<bool, string> CompleteMethod) { }
        public void UpdateConsent(UserConsent consent, UserConsent ccpaConsent) { }
    }
#endif
}
