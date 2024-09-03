using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if BBG_ADMOB
using GoogleMobileAds.Api;
#endif

namespace BBG.MobileTools
{
	public class AdMobNetworkHandler : AdNetworkHandler
	{
		#region Member Variables

		#if BBG_ADMOB
		private BannerView			bannerView;
		private InterstitialAd		interstitialAd;
		private RewardedAd			rewardedAd;
		private bool				showBannerAd;
		private float				bannerHeight;
		#endif

		#endregion

		#region Properties

		protected override string LogTag { get { return "AdMob"; } }

		private string BannerAdUnitId		{ get { return MobileAdsSettings.Instance.adMobConfig.BannerPlacementId; } }
		private string InterstitialAdUnitId	{ get { return MobileAdsSettings.Instance.adMobConfig.InterstitialPlacementId; } }
		private string RewardAdUnitId		{ get { return MobileAdsSettings.Instance.adMobConfig.RewardPlacementId; } }

		#endregion

		#region Protected Methods

		protected override void DoInitialize()
		{
			GameDebugManager.Log(LogTag, "Initializing AdMob");

			#if BBG_ADMOB

			// Initialize AdMob
			MobileAds.Initialize((Status) =>
			{
				isInitialized = true;

				// Set the text device ids
				List<string> testDeviceIds = MobileAdsSettings.Instance.adMobConfig.DeviceTestIds;

				if (testDeviceIds.Count > 0)
				{
					MobileAds.SetRequestConfiguration(new RequestConfiguration.Builder().SetTestDeviceIds(testDeviceIds).build());
				}

				// Make sure an instance of InvokeOnMainThread is created
				InvokeOnMainThread.CreateInstance();
			 
				// If we are using AdMob for banner ads then pre-load one now
				if (bannerAdsEnabled)
				{
					GameDebugManager.Log(LogTag, "Banner ads enabled, Unit Id: " + BannerAdUnitId);

					showBannerAd = MobileAdsSettings.Instance.adMobConfig.ShowBannerOnStart;

					PreLoadBannerAd();
				}

				// If we are using AdMob for interstitial ads then pre-load one now
				if (interstitialAdsEnabled)
				{
					GameDebugManager.Log(LogTag, "Interstitial ads enabled, Unit Id: " + InterstitialAdUnitId);

					PreLoadInterstitialAd();
				}

				// If we are using AdMob for reward ads then pre-load one now
				if (rewardAdsEnabled)
				{
					GameDebugManager.Log(LogTag, "Reward ads enabled, Unit Id: " + RewardAdUnitId);

					PreLoadRewardAd();
				}
			});

			#else

			GameDebugManager.LogError(LogTag, "AdMob has not been setup in Mobile Ads Settings");

			#endif //BBG_ADMOB
		}

		protected override void DoLoadBannerAd()
		{
			#if BBG_ADMOB
			// Only load a new banner ad if the ad stat is none
			if (BannerAdState == AdState.None)
			{
				CreateBannerAd();
			}
			#endif
		}

		protected override void DoShowBannerAd()
		{
			#if BBG_ADMOB
			showBannerAd = true;

			switch (BannerAdState)
			{
				case AdState.None:
					CreateBannerAd();
					break;
				case AdState.Loaded:
					bannerView.Show();
					BannerAdState = AdState.Shown;
					NotifyBannerAdShown();
					break;
				default:
					GameDebugManager.Log(LogTag, "DoShowBannerAd: Nothing will happen because BannerAdState is: " + BannerAdState);
					break;
			}

			#endif
		}

		protected override void DoHideBannerAd()
		{
			#if BBG_ADMOB
			showBannerAd = false;

			if (BannerAdState == AdState.Shown)
			{
				bannerView.Hide();
				BannerAdState = AdState.Loaded;
				NotifyBannerAdHidden();
			}
			else
			{
				GameDebugManager.Log(LogTag, "DoHideBannerAd: Nothing will happen because BannerAdState is: " + BannerAdState);
			}
			#endif
		}

		protected override void DoLoadInterstitialAd()
		{
			#if BBG_ADMOB
			if (interstitialAd != null)
			{
				interstitialAd.Destroy();
				interstitialAd = null;
			}

			NotifyInterstitialAdLoading();

			InterstitialAd.Load(InterstitialAdUnitId, CreateAdRequestBuilder(), InterstitialAdLoad);

			#endif
		}

		protected override void DoShowInterstitialAd()
		{
			#if BBG_ADMOB
			NotifyInterstitialAdShowing();
			interstitialAd.Show();
			#endif
		}

		protected override void DoLoadRewardAd()
		{
			#if BBG_ADMOB
			if (rewardedAd != null)
			{
				rewardedAd.Destroy();
				rewardedAd = null;
			}

			NotifyRewardAdLoading();

			RewardedAd.Load(RewardAdUnitId, CreateAdRequestBuilder(), RewardAdLoad);
			#endif
		}

		protected override void DoShowRewardAd()
		{
			#if BBG_ADMOB
			if (rewardedAd != null && rewardedAd.CanShowAd())
			{
				NotifyRewardAdShowing();

				rewardedAd.Show((Reward reward) =>
				{
					RewardAdRewarded(reward.Type, reward.Amount);
				});
			}
			else
			{
				PreLoadRewardAd();
			}
			#endif
		}

		protected override void DoAdsRemoved(bool dontRemoveRewardAds)
		{
			#if BBG_ADMOB
			if (bannerView != null)
			{
				bannerView.Destroy();
				bannerView = null;
			}

			if (interstitialAd != null)
			{
				interstitialAd.Destroy();
				interstitialAd = null;
			}

			if (rewardAdsEnabled && !dontRemoveRewardAds)
			{
				rewardedAd.Destroy();
				rewardedAd = null;
			}
			#endif
		}

		protected override void ConsentStatusUpdated()
		{
			// Consent status will be set next time an ad loads
		}

		protected override float DoGetBannerHeightInPixels()
		{
			#if BBG_ADMOB //&& !UNITY_EDITOR

			if (bannerHeight == 0)
			{
				if (bannerView != null)
				{
					bannerHeight = bannerView.GetHeightInPixels();
				}
				else
				{
					BannerView tempView = new BannerView(BannerAdUnitId, GetBannerAdSize(), AdPosition.Bottom);

					bannerHeight = tempView.GetHeightInPixels();

					tempView.Destroy();
				}
			}

			return bannerHeight;

			#else

			return 0f;

			#endif
		}

		protected override MobileAdsSettings.BannerPosition DoGetBannerPosition()
		{
			return MobileAdsSettings.Instance.adMobConfig.BannerPosition;
		}

		#endregion

		#region Private Methods

		#if BBG_ADMOB

		/// <summary>
		/// Creates and loads a new BannerView
		/// </summary>
		private void CreateBannerAd()
		{
			BannerAdState = AdState.Loading;

			NotifyBannerAdLoading();

			bannerView = new BannerView(BannerAdUnitId, GetBannerAdSize(), GetAdMobBannerPosition());
		
			bannerView.OnBannerAdLoaded		+= BannerAdLoaded;
			bannerView.OnBannerAdLoadFailed	+= BannerAdFailedToLoad;

			bannerView.LoadAd(CreateAdRequestBuilder());
			bannerView.Hide();
		}

		/// <summary>
		/// Gets the AdSize that is set in the settings
		/// </summary>
		private AdSize GetBannerAdSize()
		{
			switch (MobileAdsSettings.Instance.adMobConfig.BannerSize)
			{
				case MobileAdsSettings.AdMobConfig.Config.BannerSize.Banner:
					return AdSize.Banner;
				case MobileAdsSettings.AdMobConfig.Config.BannerSize.IABBanner:
					return AdSize.IABBanner;
				case MobileAdsSettings.AdMobConfig.Config.BannerSize.Leaderboard:
					return AdSize.Leaderboard;
				case MobileAdsSettings.AdMobConfig.Config.BannerSize.MediumRectangle:
					return AdSize.MediumRectangle;
				case MobileAdsSettings.AdMobConfig.Config.BannerSize.Adaptive:
					return AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
			}

			return AdSize.Banner;
		}

		private AdRequest CreateAdRequestBuilder()
		{
			AdRequest request = new AdRequest();

			if (consentStatus == MobileAdsManager.ConsentType.NonPersonalized)
			{
				request.Extras.Add("npa", "1");
			}

			return request;
		}

		private AdPosition GetAdMobBannerPosition()
		{
			// Set the ads position
			switch (MobileAdsManager.Instance.BannerAdHandler.GetBannerPosition())
			{
				case MobileAdsSettings.BannerPosition.Top:
					return AdPosition.Top;
				case MobileAdsSettings.BannerPosition.TopLeft:
					return AdPosition.TopLeft;
				case MobileAdsSettings.BannerPosition.TopRight:
					return AdPosition.TopRight;
				case MobileAdsSettings.BannerPosition.Bottom:
					return AdPosition.Bottom;
				case MobileAdsSettings.BannerPosition.BottomLeft:
					return AdPosition.BottomLeft;
				case MobileAdsSettings.BannerPosition.BottomRight:
					return AdPosition.BottomRight;
			}

			return AdPosition.Bottom;
		}

		#region Banner Ad Events

		private void BannerAdLoaded()
		{
			InvokeOnMainThread.Action((object[] obj) => 
			{
				BannerAdState = AdState.Loaded;
				NotifyBannerAdLoaded();

				if (showBannerAd && preLoadBannerAds)
				{
					ShowBannerAd();
				}
			});
		}

		private void BannerAdFailedToLoad(LoadAdError e)
		{
			InvokeOnMainThread.Action((object[] obj) =>
			{
				string message = string.Format("Failed to load banner ad\nCode: {0}\n, Message: {1}\n, Cause: {2}\n, Domain: {3}",
					e.GetCode(),
					e.GetMessage(),
					e.GetCause(),
					e.GetDomain());

				bannerView.Destroy();
				bannerView = null;

				if (BannerAdState == AdState.Shown)
				{
					NotifyBannerAdHidden();
				}

				BannerAdState = AdState.None;

				NotifyBannerAdFailedToLoad(message);
			});
		}

		#endregion

		#region Interstitial Ad Events

		private void InterstitialAdLoad(InterstitialAd ad, LoadAdError error)
		{
			if (error != null)
			{
				InvokeOnMainThread.Action((object[] obj) =>
				{
					string message = string.Format("Failed to load interstital ad\nCode: {0}\n, Message: {1}\n, Cause: {2}\n, Domain: {3}",
						error.GetCode(),
						error.GetMessage(),
						error.GetCause(),
						error.GetDomain());

					NotifyInterstitialAdFailedToLoad(message);
				});

				return;
			}

			if (ad == null)
			{
				InvokeOnMainThread.Action((object[] obj) =>
				{
					NotifyInterstitialAdFailedToLoad("Failed to laod interstitial, ad was null");
				});

				return;
			}

			interstitialAd = ad;

			interstitialAd.OnAdFullScreenContentClosed += InterstitialAdClosed;

			InvokeOnMainThread.Action((object[] obj) => 
			{
				NotifyInterstitialAdLoaded();
			});
		}

		private void InterstitialAdClosed()
		{
			InvokeOnMainThread.Action((object[] obj) => 
			{
				NotifyInterstitialAdClosed();

				PreLoadInterstitialAd();
			});
		}

		#endregion // Interstitial Ad Events

		#region Reward Ad Events

		private void RewardAdLoad(RewardedAd ad, LoadAdError error)
		{
			if (error != null)
			{
				InvokeOnMainThread.Action((object[] obj) =>
				{
					string message = string.Format("Failed to load interstital ad\nCode: {0}\n, Message: {1}\n, Cause: {2}\n, Domain: {3}",
						error.GetCode(),
						error.GetMessage(),
						error.GetCause(),
						error.GetDomain());

					NotifyRewardAdFailedToLoad(message);
				});

				return;
			}

			if (ad == null)
			{
				InvokeOnMainThread.Action((object[] obj) =>
				{
					NotifyRewardAdFailedToLoad("Failed to laod rewarded, ad was null");
				});

				return;
			}

			rewardedAd = ad;

			rewardedAd.OnAdFullScreenContentClosed += RewardAdClosed;

			InvokeOnMainThread.Action((object[] obj) =>
			{
				NotifyRewardAdLoaded();
			});
		}

		private void RewardAdClosed()
		{
			InvokeOnMainThread.Action((object[] obj) =>
			{
				NotifyRewardAdClosed();

				PreLoadRewardAd();
			});
		}

		private void RewardAdRewarded(string id, double amount)
		{
			InvokeOnMainThread.Action((object[] obj) => 
			{
				NotifyRewardAdGranted(id, amount);
			});
		}

		#endregion // Reward Ad Events

		#endif

		#endregion
	}
}
