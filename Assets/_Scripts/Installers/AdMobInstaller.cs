using Zenject;

namespace _Scripts.AdMob
{
    public class AdMobInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AdMobInitializer>().AsSingle();
        }
    }
}