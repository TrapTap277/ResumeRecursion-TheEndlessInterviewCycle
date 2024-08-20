using Zenject;

namespace _Scripts.AdMob
{
    public class AdMobInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AdMobInitializer>().AsSingle();
        }
    }
}