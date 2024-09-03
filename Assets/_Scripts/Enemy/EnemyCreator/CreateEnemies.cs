using System;
using System.Collections.Generic;
using _Scripts.Enemy.SO;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Scripts.Enemy.EnemyCreator
{
    public class CreateEnemies : IInitializable
    {
        private readonly List<Transform> _spawnPoints;
        
        private readonly EnemySo _enemySo;

        private readonly List<EnemySo> _enemies;

        public CreateEnemies(List<Transform> spawnPoints, List<EnemySo> enemies)
        {
            _spawnPoints = spawnPoints;
            _enemies = enemies;
        }

        public void Initialize()
        {
            Create();
        }

        public void Create()
        {
            var randomEnemy = Random.Range(0, _enemies.Count);
            var randomType = Random.Range(0, 3);
            var enemyType = (EnemyType)randomType;
            
            var creator = SetEnemyCreator();
            creator.SetSpawnPoints(_spawnPoints);
            creator.Create(enemyType);
        }

        private EnemyCreator SetEnemyCreator()
        {
            EnemyCreator creator = null;

            var specif = EnemySpecific.Bug;

            switch (specif)
            {
                case EnemySpecific.None:
                    break;
                case EnemySpecific.Default:
                {
                    creator = new DefaultEnemyCreator();
                    break;
                }
                case EnemySpecific.Bug:
                    creator = new BugEnemyCreator();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (creator != null) return creator;

            return new DefaultEnemyCreator();
        }
    }
}