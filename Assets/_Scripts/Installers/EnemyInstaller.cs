using System.Collections.Generic;
using _Scripts.Enemy.EnemyCreator;
using _Scripts.Enemy.SO;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemySo defaultEnemySo;
        [SerializeField] private List<Transform> enemiesSpawnPoint;

        public override void InstallBindings()
        {
            Container.Bind<List<Transform>>().FromInstance(enemiesSpawnPoint);
            Container.Bind<EnemySo>().FromInstance(defaultEnemySo);
            Container.BindInterfacesTo<CreateEnemies>().AsSingle();
        }
    }
}