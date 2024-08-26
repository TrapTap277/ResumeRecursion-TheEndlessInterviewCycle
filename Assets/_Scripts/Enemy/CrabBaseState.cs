namespace _Scripts.Enemy
{
    public abstract class CrabBaseState 
    {
        public abstract void Enter(CrabStateMachine stateMachine);
        public abstract void Update(CrabStateMachine stateMachine);
        public abstract void Exit(CrabStateMachine stateMachine);
    }
    
    public abstract class GolemBaseState
    {
        public abstract void Enter(GolemStateMachine stateMachine);
        public abstract void Update(GolemStateMachine stateMachine);
        public abstract void Exit(GolemStateMachine stateMachine);
    }
    
    public abstract class WatcherBaseState
    {
        public abstract void Enter(WatcherStateMachine stateMachine);
        public abstract void Update(WatcherStateMachine stateMachine);
        public abstract void Exit(WatcherStateMachine stateMachine);
    }
}