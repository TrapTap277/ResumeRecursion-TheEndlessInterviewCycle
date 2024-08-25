using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyDying : EnemyBaseState
    {
        private const string DIE = "Die";
        private const float TIME_TO_DIE = 3;

        private GameObject _enemy;

        public override void Enter(EnemyStateMachine stateMachine)
        {
            _enemy = stateMachine.gameObject;
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, DIE);
            animationSwitcher.SwitchAnimation();
            Destroy();
            Debug.Log("Die");
        }

        public override void Update(EnemyStateMachine stateMachine)
        {
        }

        public override void Exit(EnemyStateMachine stateMachine)
        {
        }


        private void Destroy()
        {
            Object.Destroy(_enemy, TIME_TO_DIE);
        }
    }
}