using System.Collections.Generic;
using _Scripts.Enemy.AttackLogic;
using _Scripts.Enemy.Health;
using _Scripts.Enemy.SO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Scripts.Enemy.EnemyCreator
{
    public abstract class EnemyCreator
    {
        private static List<Transform> _transforms;

        protected const string CRAB_PATH = "Prefabs/Crub";
        protected const string GOLEM_PATH = "Prefabs/Golem";
        protected const string WATCHER_PATH = "Prefabs/Watcher";

        private EnemyStats _enemyStats;

        public void SetSpawnPoints(List<Transform> transforms)
        {
            _transforms = transforms;
        }

        public void SetEnemyParameters(EnemyStats enemyStats)
        {
            _enemyStats = enemyStats;
        }

        public GameObject Create(EnemyType enemyType)
        {
            return enemyType switch
            {
                EnemyType.Crab => CreateCrabEnemy(),
                EnemyType.Golem => CreateGolemEnemy(),
                EnemyType.Watcher => CreateWatcherEnemy()
            };
        }

        protected abstract GameObject CreateCrabEnemy();
        protected abstract GameObject CreateGolemEnemy();
        protected abstract GameObject CreateWatcherEnemy();

        protected void SetupEnemy(GameObject enemyObject, EnemyAttack attackComponent)
        {
            var randomPos = Random.Range(0, _transforms.Count);
            var currentEnemy = enemyObject.GetComponent<CurrentEnemy>();
            currentEnemy.SetEnemy(_enemyStats);
            var health = Object.FindObjectOfType<PlayerHealth>();
            enemyObject.transform.position = _transforms[randomPos].position;

            attackComponent.Construct(currentEnemy, health);
        }
    }
}