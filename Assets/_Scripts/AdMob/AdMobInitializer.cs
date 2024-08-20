using GoogleMobileAds.Api;
using UnityEngine;
using Zenject;

namespace _Scripts.AdMob
{
    public class AdMobInitializer : IInitializable
    {
        private static void InitAdMob()
        {
            MobileAds.Initialize(initStatus => { Debug.Log("Injected " + initStatus); });
        }

        public void Initialize()
        {
            InitAdMob();
        }
    }
}