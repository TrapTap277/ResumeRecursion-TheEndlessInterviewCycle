using UnityEngine;

namespace _Scripts.Enemy.EnemyCreator
{
    public class DefaultEnemyCreator : EnemyCreator
    {
        private const string CRAB_PATH = "Prefabs/Strange_Crab";
        private const string RED_GOLEM_PATH = "Prefabs/Golem_Red";
        private const string GREEN_GOLEM_PATH = "Prefabs/Golem_Green";
        private const string GREEN_WATCHER_PATH = "Prefabs/Watcher_Red";
        private const string RED_WATCHER_PATH = "Prefabs/Watcher_Green";

        public override CrabStateMachine CreateCrabEnemy()
        {
            var newCrab = Resources.Load<GameObject>(CRAB_PATH);
            var crab = Object.Instantiate(newCrab);
            var crabComponent = crab.AddComponent<CrabStateMachine>();
            return crabComponent;
        }

        public override GolemStateMachine CreateGolemEnemy()
        {
            var newGolem = Resources.Load<GameObject>(Random.Range(0, 2) == 0 ? GREEN_GOLEM_PATH : RED_GOLEM_PATH);
            var golem = Object.Instantiate(newGolem);
            var golemComponent = golem.AddComponent<GolemStateMachine>();
            return golemComponent;
        }

        public override WatcherStateMachine CreateWatcherEnemy()
        {
            var newWatcher =
                Resources.Load<GameObject>(Random.Range(0, 2) == 0 ? RED_WATCHER_PATH : GREEN_WATCHER_PATH);
            var watcher = Object.Instantiate(newWatcher);
            var watcherComponent = watcher.AddComponent<WatcherStateMachine>();
            return watcherComponent;
        }
    }
}