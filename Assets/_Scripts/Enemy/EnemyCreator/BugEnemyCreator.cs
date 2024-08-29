using _Scripts.Enemy.AttackLogic;
using _Scripts.Enemy.StateLogic;
using UnityEngine;

namespace _Scripts.Enemy.EnemyCreator
{
    public class BugEnemyCreator : EnemyCreator
    {
        protected override GameObject CreateCrabEnemy()
        {
            var newCrab = Object.Instantiate(Resources.Load<GameObject>(CRAB_PATH));
            newCrab.AddComponent<CrabStateMachine>();
            SetupEnemy(newCrab, newCrab.GetComponent<EnemyAttack>());
            return newCrab;
        }

        protected override GameObject CreateGolemEnemy()
        {
            var newGolem = Object.Instantiate(Resources.Load<GameObject>(GOLEM_PATH));
            newGolem.AddComponent<GolemStateMachine>();
            SetupEnemy(newGolem, newGolem.GetComponent<EnemyAttack>());
            return newGolem;
        }

        protected override GameObject CreateWatcherEnemy()
        {
            var newWatcher = Object.Instantiate(Resources.Load<GameObject>(WATCHER_PATH));
            newWatcher.AddComponent<WatcherStateMachine>();
            SetupEnemy(newWatcher, newWatcher.GetComponent<EnemyAttack>());
            return newWatcher;
        }
    }
}