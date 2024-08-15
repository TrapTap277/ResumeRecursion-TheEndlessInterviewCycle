using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private JumpBehaviour jumpBehaviour;
        [SerializeField] private ShiftingBehaviour shiftingBehaviour;
        [SerializeField] private WalkBehaviour walkBehaviour;
        [SerializeField] private RunBehaviour runBehaviour;
        [SerializeField] private CameraLook cameraLook;
        [SerializeField] private AttackBehaviour attackBehaviour;
        private const string SHIFTING_ID = "Shifting";
        private const string MOVE_ID = "Move";
        private const string RUN_ID = "Run";
        private const string CAMERA_ID = "Camera";

        public override void InstallBindings()
        {
            Container.Bind<IJump>().To<JumpBehaviour>().FromInstance(jumpBehaviour).AsSingle();
            Container.Bind<IMove>()
                .WithId(SHIFTING_ID)
                .To<ShiftingBehaviour>()
                .FromInstance(shiftingBehaviour)
                .AsSingle();
            Container.Bind<IMove>().WithId(MOVE_ID).To<WalkBehaviour>().FromInstance(walkBehaviour).AsSingle();
            Container.Bind<IMove>().WithId(RUN_ID).To<RunBehaviour>().FromInstance(runBehaviour).AsSingle();
            Container.Bind<IMove>().WithId(CAMERA_ID).To<CameraLook>().FromInstance(cameraLook).AsSingle();
            Container.Bind<IAttack>().To<AttackBehaviour>().FromInstance(attackBehaviour).AsSingle();
            Container.Bind<InputReader>().AsSingle();
        }
    }
}