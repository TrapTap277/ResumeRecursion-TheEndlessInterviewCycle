using System.Collections.Generic;
using _Scripts.AdMob;
using _Scripts.NecessaryInterfaces;
using GoogleMobileAds.Api;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class BootstrapInjector : MonoBehaviour
    {
        private IShowAdvertisement _showAdvertisement;

        private readonly List<IInit> _inits = new List<IInit>();

        private readonly List<Installer> _installers = new List<Installer>();
        
        private AdMobInstaller _adMobInstaller;
        private HeroInstaller _heroInstaller;

        [Inject]
        private void Construct(AdMobInstaller adMobInstaller, HeroInstaller heroInstaller)
        {
            _heroInstaller = heroInstaller;
            _adMobInstaller = adMobInstaller;
            
            AddInstallers();
            Initialize();
            InstallBindings();
        }

        private void Start()
        {
            // InstallBindings();


            // BaseAdvertisementLoader<RewardedAd> banner = new RewardedAdd();
            // _showAdvertisement = (IShowAdvertisement) banner;
            // banner.Load();

            // BaseAdvertisementLoader<BannerView> banner1 = new BannerAdvertisement();
            // _showAdvertisement = (IShowAdvertisement) banner1;
            // banner1.Load();
            // //
            // BaseAdvertisementLoader<InterstitialAd> banner2 = new InterstitialAdvertisement();
            // _showAdvertisement = (IShowAdvertisement) banner2;
            // banner2.Load();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) _showAdvertisement.Show();

            if (Input.GetKeyDown(KeyCode.C)) CreateAd();
        }

        private void CreateAd()
        {
            BaseAdvertisementLoader<InterstitialAd> banner2 = new InterstitialAdvertisement();
            _showAdvertisement = (IShowAdvertisement)banner2;
            banner2.Load();
        }

        private void Initialize()
        {
            foreach (var init in _inits) init.Init();
        }

        private void InstallBindings()
        {
            foreach (var installer in _installers)
                installer.InstallBindings();
        }

        private void AddInstallers()
        {
            _installers.Add(_adMobInstaller);
            _installers.Add(_heroInstaller);
        }
    }
}