using System.Collections.Generic;
using _Scripts.NecessaryInterfaces;
using GoogleMobileAds.Api;
using UnityEngine;
using Zenject;

namespace _Scripts.AdMob
{
    public class BootstrapInjector : MonoBehaviour
    {
        private IShowAdvertisement _showAdvertisement;

        [Inject] private List<IInit> _inits = new List<IInit>();

        private void Awake()
        {
            foreach (var init in _inits) init.Init();
        }

        private void Start()
        {
            // BaseAdvertisementLoader<RewardedAd> banner = new RewardedAdd();
            // _showAdvertisement = (IShowAdvertisement) banner;
            // banner.Load();

            // BaseAdvertisementLoader<BannerView> banner1 = new BannerAdvertisement();
            // _showAdvertisement = (IShowAdvertisement) banner1;
            // banner1.Load();
            // //
            BaseAdvertisementLoader<InterstitialAd> banner2 = new InterstitialAdvertisement();
            _showAdvertisement = (IShowAdvertisement) banner2;
            banner2.Load();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) _showAdvertisement.Show();

            if (Input.GetKeyDown(KeyCode.C)) CreateAd();
        }

        private void CreateAd()
        {
            BaseAdvertisementLoader<InterstitialAd> banner2 = new InterstitialAdvertisement();
            _showAdvertisement = (IShowAdvertisement) banner2;
            banner2.Load();
        }
    }
}