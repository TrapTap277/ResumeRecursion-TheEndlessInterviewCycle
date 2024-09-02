using _Scripts.AdMob;
using Zenject;

namespace _Scripts.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BootstrapInjector>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<AdMobInstaller>().AsSingle();
            Container.Bind<HeroInstaller>().AsSingle();
        }
    }
}