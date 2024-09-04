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
        
        private readonly EnemyStats _enemyStats;

        private readonly List<EnemyStats> _enemies;

        private EnemySpecific _specific = EnemySpecific.Default;

        public CreateEnemies(List<Transform> spawnPoints, List<EnemyStats> enemies)
        {
            _spawnPoints = spawnPoints;
            _enemies = enemies;
        }

        public void Initialize()
        {
            Create();
        }

        public void ChangeSpecificAndCreate(EnemySpecific specific)
        {
            _specific = specific;
            Create();
        }

        private void Create()
        {
            var enemyType = SetRandomEnemy();

            var creator = SetEnemyCreator();
            creator.SetSpawnPoints(_spawnPoints);
            creator.Create(enemyType.Type);
        }

        private EnemyStats SetRandomEnemy()
        {
            var randomEnemy = Random.Range(0, _enemies.Count);
            var enemyType = _enemies[randomEnemy];
            return enemyType;
        }

        private EnemyCreator SetEnemyCreator()
        {
            EnemyCreator creator = null;

            switch (_specific)
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