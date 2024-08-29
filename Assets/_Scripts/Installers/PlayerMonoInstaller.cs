using _Scripts.Enemy.Health;
using Zenject;

namespace _Scripts.Installers
{
    public class PlayerMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerHealth>().FromInstance(FindObjectOfType<PlayerHealth>());
        }
    }
}