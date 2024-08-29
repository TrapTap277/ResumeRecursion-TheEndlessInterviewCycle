using System;
using _Scripts.Enemy.AttackLogic;
using _Scripts.Enemy.Health;
using _Scripts.Enemy.SO;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace _Scripts.Enemy.EnemyCreator
{
    public abstract class EnemyCreator
    {
        protected const string CRAB_PATH = "Prefabs/Crub";
        protected const string GOLEM_PATH = "Prefabs/Golem";
        protected const string WATCHER_PATH = "Prefabs/Watcher";

        public GameObject Create(EnemyType enemyType)
        {
            return enemyType switch
            {
                EnemyType.Crab => CreateCrabEnemy(),
                EnemyType.Golem => CreateGolemEnemy(),
                EnemyType.Watcher => CreateWatcherEnemy(),
                _ => throw new ArgumentException("Unknown enemy type", nameof(enemyType))
            };
        }

        protected abstract GameObject CreateCrabEnemy();
        protected abstract GameObject CreateGolemEnemy();
        protected abstract GameObject CreateWatcherEnemy();

        protected void SetupEnemy(GameObject enemyObject, EnemyAttack attackComponent)
        {
            var currentEnemy = enemyObject.GetComponent<CurrentEnemy>();
            var health = Object.FindObjectOfType<PlayerHealth>();

            attackComponent.Construct(currentEnemy, health);
        }
    }
}