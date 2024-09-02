using _Scripts.Bug;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class BugInstaller : MonoInstaller
    {
        [SerializeField] private BugCreator bugCreator;
        [SerializeField] private int initialBugCount = 5;

        public override void InstallBindings()
        {
            Container.Bind<GameObject>().FromInstance(bugCreator.bugPrefab).AsSingle();
            Container.BindFactory<Vector3, Quaternion, Transform, FixBug, FixBug.Factory>()
                .FromFactory<CustomFixBugFactory>()
                .Lazy();

            Container.Bind<int>().FromInstance(initialBugCount).AsSingle();
            Container.Bind<BugCreator>().FromInstance(bugCreator).AsSingle();
            Container.BindInterfacesTo<BugCounter>().AsSingle().WithArguments(initialBugCount, bugCreator);
        }

        private class CustomFixBugFactory : IFactory<Vector3, Quaternion, Transform, FixBug>
        {
            private readonly DiContainer _container;
            private readonly GameObject _bugPrefab;

            public CustomFixBugFactory(DiContainer container, GameObject bugPrefab)
            {
                _container = container;
                _bugPrefab = bugPrefab;
            }

            public FixBug Create(Vector3 position, Quaternion rotation, Transform parent)
            {
                return _container.InstantiatePrefabForComponent<FixBug>(_bugPrefab, position, rotation, parent);
            }
        }
    }
}