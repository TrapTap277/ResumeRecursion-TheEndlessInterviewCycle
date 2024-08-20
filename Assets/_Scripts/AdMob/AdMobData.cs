namespace _Scripts.AdMob
{
    public abstract class AdMobData<T>
    {
        protected T Ad;

        protected abstract void Create();

#if UNITY_ANDROID
        protected const string UNIT_ID = "ca-app-pub-6828495463626405~8812560754";

        protected string BannerCode = "ca-app-pub-3940256099942544/6300978111";
        protected string InterstitialCode = "ca-app-pub-3940256099942544/1033173712";
        protected string RewardedCode = "ca-app-pub-3940256099942544/5224354917";
        protected string NativeCode = "ca-app-pub-3940256099942544/2247696110";

#elif UNITY_IOS
        protected string BannerCode = "ca-app-pub-3940256099942544/2934735716";
        protected string InterstitialCode = "ca-app-pub-3940256099942544/4411468910";
        protected string RewardedCode = "ca-app-pub-3940256099942544/1712485313";
        protected string NativeCode = "ca-app-pub-3940256099942544/3986624511";

#else

        protected const string UNIT_ID = "unused";

#endif
    }
}