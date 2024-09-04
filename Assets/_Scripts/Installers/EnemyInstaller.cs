using System.Collections.Generic;
using _Scripts.Enemy.EnemyCreator;
using _Scripts.Enemy.SO;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private List<EnemyStats> enemies;
        [SerializeField] private List<Transform> enemiesSpawnPoint;
        
        public override void InstallBindings()
        {
            Container.Bind<List<Transform>>().FromInstance(enemiesSpawnPoint);
            Container.Bind<List<EnemyStats>>().FromInstance(enemies);
            Container.BindInterfacesTo<CreateEnemies>().AsSingle();
        }
    }
}