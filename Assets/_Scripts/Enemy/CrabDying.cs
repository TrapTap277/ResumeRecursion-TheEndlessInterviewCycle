using UnityEngine;

namespace _Scripts.Enemy
{
    public class CrabDying : CrabBaseState
    {
        private const string DIE = "Die";
        private const float TIME_TO_DIE = 3;

        private GameObject _enemy;

        public override void Enter(CrabStateMachine stateMachine)
        {
            _enemy = stateMachine.gameObject;
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, DIE);
            animationSwitcher.SwitchAnimation();
            Destroy();
            Debug.Log("Die");
        }

        public override void Update(CrabStateMachine stateMachine)
        {
        }

        public override void Exit(CrabStateMachine stateMachine)
        {
        }


        private void Destroy()
        {
            Object.Destroy(_enemy, TIME_TO_DIE);
        }
    }
    
    public class GolemDying : GolemBaseState
    {
        private const string DIE = "Die";
        private const float TIME_TO_DIE = 3;

        private GameObject _enemy;

        public override void Enter(GolemStateMachine stateMachine)
        {
            _enemy = stateMachine.gameObject;
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, DIE);
            animationSwitcher.SwitchAnimation();
            Destroy();
            Debug.Log("Die");
        }

        public override void Update(GolemStateMachine stateMachine)
        {
        }

        public override void Exit(GolemStateMachine stateMachine)
        {
        }


        private void Destroy()
        {
            Object.Destroy(_enemy, TIME_TO_DIE);
        }
    }

    
    public class WatcherDying : WatcherBaseState
    {
        private const string DIE = "Die";
        private const float TIME_TO_DIE = 3;

        private GameObject _enemy;

        public override void Enter(WatcherStateMachine stateMachine)
        {
            _enemy = stateMachine.gameObject;
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, DIE);
            animationSwitcher.SwitchAnimation();
            Destroy();
            Debug.Log("Die");
        }

        public override void Update(WatcherStateMachine stateMachine)
        {
        }

        public override void Exit(WatcherStateMachine stateMachine)
        {
        }


        private void Destroy()
        {
            Object.Destroy(_enemy, TIME_TO_DIE);
        }
    }

}