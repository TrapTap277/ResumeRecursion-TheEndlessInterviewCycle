using _Scripts.Enemy.Health;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Scripts.Player
{
    public class InputInstaller : MonoInstaller
    {
        [FormerlySerializedAs("_playerConfig")] [SerializeField] private PlayerConfig playerConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<IJump>().To<JumpBehaviour>().FromInstance(playerConfig.jumpBehaviour).AsSingle();
            Container.Bind<IMove>()
                .WithId(playerConfig.shiftingID)
                .To<ShiftingBehaviour>()
                .FromInstance(playerConfig.shiftingBehaviour)
                .AsSingle();
            Container.Bind<IMove>().WithId(playerConfig.moveID).To<WalkBehaviour>().FromInstance(playerConfig.walkBehaviour).AsSingle();
            Container.Bind<IMove>().WithId(playerConfig.runID).To<RunBehaviour>().FromInstance(playerConfig.runBehaviour).AsSingle();
            Container.Bind<IMove>().WithId(playerConfig.cameraID).To<CameraLook>().FromInstance(playerConfig.cameraLook).AsSingle();
            Container.Bind<IAttack>().To<AttackBehaviour>().FromInstance(playerConfig.attackBehaviour).AsSingle();
            Container.Bind<InputReader>().AsSingle();

            //
            //
            //
            //
            //
            // Container.Bind<IJump>().To<JumpBehaviour>().FromComponentInHierarchy().AsSingle();
            // Container.Bind<IMove>()
            //     .WithId(playerConfig.shiftingID)
            //     .To<ShiftingBehaviour>()
            //     .FromComponentInHierarchy()
            //     .AsSingle();
            // Container.Bind<IMove>().WithId(playerConfig.moveID).To<WalkBehaviour>().FromComponentInHierarchy().AsSingle();
            // Container.Bind<IMove>().WithId(playerConfig.runID).To<RunBehaviour>().FromComponentInHierarchy().AsSingle();
            // Container.Bind<IMove>().WithId(playerConfig.cameraID).To<CameraLook>().FromComponentInHierarchy().AsSingle();
            // Container.Bind<IAttack>().To<AttackBehaviour>().FromComponentInHierarchy().AsSingle();
            // Container.Bind<InputReader>().AsSingle();
        }
    }
}