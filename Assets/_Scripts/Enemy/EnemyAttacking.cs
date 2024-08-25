using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyAttacking : EnemyBaseState
    {
        private const string ATTACK_ANIMATION = "Attack";
        private const string ATTACK_ANIMATION1 = "Attack1";
        private const string ATTACK_ANIMATION2 = "Attack2";
        private const string ATTACK_ANIMATION3 = "Attack3";
        private const string ATTACK_ANIMATION4 = "Attack4";

        private readonly List<string> _attackAnimations = new List<string>();

        private bool _isAttacking;

        public override void Enter(EnemyStateMachine stateMachine)
        {
            _attackAnimations.Add(ATTACK_ANIMATION);
            _attackAnimations.Add(ATTACK_ANIMATION1);
            _attackAnimations.Add(ATTACK_ANIMATION2);
            _attackAnimations.Add(ATTACK_ANIMATION3);
            _attackAnimations.Add(ATTACK_ANIMATION4);

            _isAttacking = true;

            Attack(stateMachine);
            stateMachine.navMeshAgent.speed = 0.1f;
        }

        private async void Attack(EnemyStateMachine stateMachine)
        {
            while (_isAttacking)
            {
                SwitchAnimation(stateMachine);
                await Task.Delay(3000);
            }
        }

        public override void Update(EnemyStateMachine stateMachine)
        {
        }

        public override void Exit(EnemyStateMachine stateMachine)
        {
            _isAttacking = false;
        }

        private void SwitchAnimation(EnemyStateMachine stateMachine)
        {
            var randomAttack = Random.Range(0, _attackAnimations.Count);
            var animationSwitcher =
                new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, _attackAnimations[randomAttack]);
            animationSwitcher.SwitchAnimation();
        }
    }
}