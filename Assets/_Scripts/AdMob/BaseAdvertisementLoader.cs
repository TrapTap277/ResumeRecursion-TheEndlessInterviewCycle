namespace _Scripts.AdMob
{
    public abstract class BaseAdvertisementLoader<T> : AdMobData<T>
    {
        public abstract void Load();

        public abstract void RegisterEventHandlers();

        public abstract void Clear();
    }
}