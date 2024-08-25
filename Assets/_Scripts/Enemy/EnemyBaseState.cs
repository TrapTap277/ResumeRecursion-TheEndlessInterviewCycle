namespace _Scripts.Enemy
{
    public abstract class EnemyBaseState
    {
        public abstract void Enter(EnemyStateMachine stateMachine);
        public abstract void Update(EnemyStateMachine stateMachine);
        public abstract void Exit(EnemyStateMachine stateMachine);
    }
}