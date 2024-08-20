using System;
using GoogleMobileAds.Api;
using UnityEngine;

namespace _Scripts.AdMob
{
    public class InterstitialAdvertisement : BaseAdvertisementLoader<InterstitialAd>, IShowAdvertisement
    {
        private AdRequest _adRequest;

        private bool _isDone;

        public override void Load()
        {
            if (_adRequest == null) Create();

            InterstitialAd.Load(UNIT_ID, _adRequest, (ad, error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " + "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : " + ad.GetResponseInfo());

                Ad = ad;
            });

            // if (Ad.CanShowAd())
            // {
            //     RegisterEventHandlers();
            //     Show();
            // }
        }

        private void RegisterReloadHandler()
        {
            // Raised when the ad closed full screen content.
            Ad.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("Interstitial Ad full screen content closed.");

                // Reload the ad so that we can show another as soon as possible.
                Load();
            };
            // Raised when the ad failed to open full screen content.
            Ad.OnAdFullScreenContentFailed += error =>
            {
                Debug.LogError("Interstitial ad failed to open full screen content " + "with error : " + error);

                // Reload the ad so that we can show another as soon as possible.
                Load();
            };
        }

        public override void RegisterEventHandlers()
        {
// Raised when the ad is estimated to have earned money.
            Ad.OnAdPaid += adValue => { Debug.Log($"Interstitial ad paid {adValue.Value} {adValue.CurrencyCode}."); };
            // Raised when an impression is recorded for an ad.
            Ad.OnAdImpressionRecorded += () => { Debug.Log("Interstitial ad recorded an impression."); };
            // Raised when a click is recorded for an ad.
            Ad.OnAdClicked += () => { Debug.Log("Interstitial ad was clicked."); };
            // Raised when an ad opened full screen content.
            Ad.OnAdFullScreenContentOpened += () => { Debug.Log("Interstitial ad full screen content opened."); };
            // Raised when the ad closed full screen content.
            Ad.OnAdFullScreenContentClosed += () => { Debug.Log("Interstitial ad full screen content closed."); };
            // Raised when the ad failed to open full screen content.
            Ad.OnAdFullScreenContentFailed += error =>
            {
                Debug.LogError("Interstitial ad failed to open full screen content " + "with error : " + error);
            };
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        protected override void Create()
        {
            if (Ad != null)
            {
                Ad.Destroy();
                Ad = null;
            }

            Debug.Log("Loading the interstitial ad.");
            _adRequest = new AdRequest();

            Load();
        }

        public void Show()
        {
            if (!Ad.CanShowAd())
            {
                Debug.LogError(Ad.CanShowAd());
                return;
            }

            if (Ad != null && Ad.CanShowAd())
            {
                Debug.Log("Showing interstitial ad.");
                Ad.Show();
            }
            else
            {
                Debug.LogError("Interstitial ad is not ready yet.");
            }

            if (!_isDone)
            {
                RegisterEventHandlers();
            }

            else
            {
                RegisterReloadHandler();
            }
        }
    }
}