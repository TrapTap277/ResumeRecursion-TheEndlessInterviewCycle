using UnityEngine;

namespace _Scripts.Enemy.StateLogic
{
    public class CrabDying : CrabBaseState
    {
        private const string DIE = "Die";
        private float _timeToDie = 3;

        private GameObject _enemy;

        public override void Enter(CrabStateMachine stateMachine)
        {
            _enemy = stateMachine.gameObject;
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, DIE);
            animationSwitcher.SwitchAnimation();
            _timeToDie = animationSwitcher.GetAnimationDuration();

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
            Object.Destroy(_enemy, _timeToDie);
        }
    }

    public class GolemDying : GolemBaseState
    {
        private const string DIE = "Die";
        private float _timeToDie = 3;

        private GameObject _enemy;

        public override void Enter(GolemStateMachine stateMachine)
        {
            _enemy = stateMachine.gameObject;
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, DIE);
            animationSwitcher.SwitchAnimation();
            _timeToDie = animationSwitcher.GetAnimationDuration();

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
            Object.Destroy(_enemy, _timeToDie);
        }
    }

    public class WatcherDying : WatcherBaseState
    {
        private const string DIE = "Die";
        private float _timeToDie = 3;

        private GameObject _enemy;

        public override void Enter(WatcherStateMachine stateMachine)
        {
            _enemy = stateMachine.gameObject;
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, DIE);
            animationSwitcher.SwitchAnimation();
            _timeToDie = animationSwitcher.GetAnimationDuration();
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
            Object.Destroy(_enemy, _timeToDie);
        }
    }
}