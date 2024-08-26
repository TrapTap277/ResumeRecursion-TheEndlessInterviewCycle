namespace _Scripts.Enemy.EnemyCreator
{
    public abstract class EnemyCreator
    {
        public abstract CrabStateMachine CreateCrabEnemy();
        public abstract GolemStateMachine CreateGolemEnemy();
        public abstract WatcherStateMachine CreateWatcherEnemy();
    }
}