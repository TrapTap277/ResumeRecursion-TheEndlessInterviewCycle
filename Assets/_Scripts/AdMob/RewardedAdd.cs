using GoogleMobileAds.Api;
using UnityEngine;

namespace _Scripts.AdMob
{
    public class RewardedAdd : BaseAdvertisementLoader<RewardedAd>, IShowAdvertisement
    {
        
        private AdRequest _request;

        protected override void Create()
        {
// Clean up the old ad before loading a new one.
            if (Ad != null)
            {
                Ad.Destroy();
                Ad = null;
            }

            Debug.Log("Loading the rewarded ad.");

            // create our request used to load the ad.
            _request = new AdRequest();

            // Load();
        }

        public override void Load()
        {
            if (_request == null) Create();

            if (Ad != null)
            {
                Ad.Destroy();
                Ad = null;
            }
            
            _request.Keywords.Add("unity-admob-sample");

                // send the request to load the ad.
            RewardedAd.Load(UNIT_ID, _request, (ad, error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " + "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : " + ad.GetResponseInfo());

                Ad = ad;
                RegisterEventHandlers();
            });
            
            
            // if (Ad.CanShowAd())
            // {
            //     RegisterEventHandlers();
            //     Show();
            //     
            //     Debug.Log(Ad.CanShowAd());
            // }
        }

        public override void RegisterEventHandlers()
        {
            Debug.Log("REGISTTERER");
// Raised when the ad is estimated to have earned money.
            Ad.OnAdPaid += adValue =>
            {
                Debug.Log($"Rewarded ad paid {adValue.Value} {adValue.CurrencyCode}.");
            };
            // Raised when an impression is recorded for an ad.
            Ad.OnAdImpressionRecorded += () => { Debug.Log("Rewarded ad recorded an impression."); };
            // Raised when a click is recorded for an ad.
            Ad.OnAdClicked += () => { Debug.Log("Rewarded ad was clicked."); };
            // Raised when an ad opened full screen content.
            Ad.OnAdFullScreenContentOpened += () => { Debug.Log("Rewarded ad full screen content opened."); };
            // Raised when the ad closed full screen content.
            Ad.OnAdFullScreenContentClosed += () => { Debug.Log("Rewarded ad full screen content closed."); };
            // Raised when the ad failed to open full screen content.
            Ad.OnAdFullScreenContentFailed += error =>
            {
                Debug.LogError("Rewarded ad failed to open full screen content " + "with error : " + error);
            };
        }

        public void RegisterReloadHandler()
        {
            // Raised when the ad closed full screen content.
            Ad.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("Rewarded Ad full screen content closed.");

                // Reload the ad so that we can show another as soon as possible.
                Load();
            };
            // Raised when the ad failed to open full screen content.
            Ad.OnAdFullScreenContentFailed += error =>
            {
                Debug.LogError("Rewarded ad failed to open full screen content " + "with error : " + error);

                // Reload the ad so that we can show another as soon as possible.
                Load();
            };
        }

        public override void Clear()
        {
            Ad.Destroy();
        }

        public void Show()
        {
            if (!Ad.CanShowAd()) return;
            
            const string REWARD_MSG = "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

            if (Ad != null && Ad.CanShowAd())
                Ad.Show(reward =>
                {
                    // TODO: Reward the user.
                    Debug.Log(string.Format(REWARD_MSG, reward.Type, reward.Amount));
                });
        }
    }
}