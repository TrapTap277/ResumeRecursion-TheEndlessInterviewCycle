using GoogleMobileAds.Api;
using UnityEngine;

namespace _Scripts.AdMob
{
    public class BannerAdvertisement : BaseAdvertisementLoader<BannerView>
    {
        public override void Load()
        {
            if (Ad == null) Create();

            var adRequest = new AdRequest();

            Debug.Log("Loading banner ad.");
            Ad.LoadAd(adRequest);

            RegisterEventHandlers();
        }

        public override void RegisterEventHandlers()
        {
// Raised when an ad is loaded into the banner view.
            Ad.OnBannerAdLoaded += () =>
            {
                Debug.Log("Banner view loaded an ad with response : " + Ad.GetResponseInfo());
            };
            // Raised when an ad fails to load into the banner view.
            Ad.OnBannerAdLoadFailed += error =>
            {
                Debug.LogError("Banner view failed to load an ad with error : " + error);
            };
            // Raised when the ad is estimated to have earned money.
            Ad.OnAdPaid += adValue =>
            {
                Debug.Log($"Banner view paid {adValue.Value} {adValue.CurrencyCode}.");
            };
            // Raised when an impression is recorded for an ad.
            Ad.OnAdImpressionRecorded += () => { Debug.Log("Banner view recorded an impression."); };
            // Raised when a click is recorded for an ad.
            Ad.OnAdClicked += () => { Debug.Log("Banner view was clicked."); };
            // Raised when an ad opened full screen content.
            Ad.OnAdFullScreenContentOpened += () => { Debug.Log("Banner view full screen content opened."); };
            // Raised when the ad closed full screen content.
            Ad.OnAdFullScreenContentClosed += () => { Debug.Log("Banner view full screen content closed."); };
        }

        public override void Clear()
        {
            if (Ad != null)
            {
                Debug.Log("Destroying banner view.");
                Ad.Destroy();
                Ad = null;
            }
        }

        protected override void Create()
        {
            Debug.Log("Creating banner view");

            if (Ad != null) Clear();

            Ad = new BannerView(UNIT_ID, AdSize.Banner, AdPosition.Top);
        }
    }
}