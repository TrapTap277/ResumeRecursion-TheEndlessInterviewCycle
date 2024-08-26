using UnityEngine;

namespace _Scripts.Enemy.EnemyCreator
{
    public class BugEnemyCreator : EnemyCreator
    {
        private const string BUG_CRAB_PATH = "Prefabs/Bug_Crub";
        private const string BUG_GOLEM_PATH = "Prefabs/Golem_Bug";
        private const string BUG_WATCHER_PATH = "Prefabs/Watcher_Bug";

        public override CrabStateMachine CreateCrabEnemy()
        {
            var newCrab = Resources.Load<GameObject>(BUG_CRAB_PATH);
            var crab = Object.Instantiate(newCrab);
            var crabComponent = crab.AddComponent<CrabStateMachine>();
            return crabComponent;
        }

        public override GolemStateMachine CreateGolemEnemy()
        {
            var newCrab = Resources.Load<GameObject>(BUG_GOLEM_PATH);

            var golem = Object.Instantiate(newCrab);
            var golemComponent = golem.AddComponent<GolemStateMachine>();
            return golemComponent;
        }

        public override WatcherStateMachine CreateWatcherEnemy()
        {
            var newCrab = Resources.Load<GameObject>(BUG_WATCHER_PATH);
            var watcher = Object.Instantiate(newCrab);
            var watcherComponent = watcher.AddComponent<WatcherStateMachine>();
            return watcherComponent;
        }
    }
}