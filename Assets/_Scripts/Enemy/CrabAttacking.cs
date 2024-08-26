using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class CrabAttacking : CrabBaseState
    {
        private const string ATTACK_ANIMATION = "Attack";
        private const string ATTACK_ANIMATION1 = "Attack1";
        private const string ATTACK_ANIMATION2 = "Attack2";
        private const string ATTACK_ANIMATION3 = "Attack3";
        private const string ATTACK_ANIMATION4 = "Attack4";

        private readonly List<string> _attackAnimations = new List<string>();

        private bool _isAttacking;

        public override void Enter(CrabStateMachine stateMachine)
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

        private async void Attack(CrabStateMachine stateMachine)
        {
            while (_isAttacking)
            {
                SwitchAnimation(stateMachine);
                await Task.Delay(3000);
            }
        }

        public override void Update(CrabStateMachine stateMachine)
        {
        }

        public override void Exit(CrabStateMachine stateMachine)
        {
            _isAttacking = false;
        }

        private void SwitchAnimation(CrabStateMachine stateMachine)
        {
            var randomAttack = Random.Range(0, _attackAnimations.Count);
            var animationSwitcher =
                new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, _attackAnimations[randomAttack]);
            animationSwitcher.SwitchAnimation();
        }
    }

    public class GolemAttacking : GolemBaseState
    {
        private const string ATTACK_ANIMATION = "Attack";
        private const string ATTACK_ANIMATION1 = "Attack1";
        private const string ATTACK_ANIMATION2 = "Attack2";
        private const string ATTACK_ANIMATION3 = "Attack3";
        private const string ATTACK_ANIMATION4 = "Attack4";

        private readonly List<string> _attackAnimations = new List<string>();

        private bool _isAttacking;

        public override void Enter(GolemStateMachine stateMachine)
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

        private async void Attack(GolemStateMachine stateMachine)
        {
            while (_isAttacking)
            {
                SwitchAnimation(stateMachine);
                await Task.Delay(3000);
            }
        }

        public override void Update(GolemStateMachine stateMachine)
        {
        }

        public override void Exit(GolemStateMachine stateMachine)
        {
            _isAttacking = false;
        }

        private void SwitchAnimation(GolemStateMachine stateMachine)
        {
            var randomAttack = Random.Range(0, _attackAnimations.Count);
            var animationSwitcher =
                new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, _attackAnimations[randomAttack]);
            animationSwitcher.SwitchAnimation();
        }
    }

    public class WatcherAttacking : WatcherBaseState
    {
        private const string ATTACK_ANIMATION = "Attack";
        private const string ATTACK_ANIMATION1 = "Attack1";

        private readonly List<string> _attackAnimations = new List<string>();

        private bool _isAttacking;

        public override void Enter(WatcherStateMachine stateMachine)
        {
            _attackAnimations.Add(ATTACK_ANIMATION);
            _attackAnimations.Add(ATTACK_ANIMATION1);

            _isAttacking = true;

            Attack(stateMachine);
            stateMachine.navMeshAgent.speed = 0.1f;
        }

        private async void Attack(WatcherStateMachine stateMachine)
        {
            while (_isAttacking)
            {
                SwitchAnimation(stateMachine);
                await Task.Delay(3000);
            }
        }

        public override void Update(WatcherStateMachine stateMachine)
        {
        }

        public override void Exit(WatcherStateMachine stateMachine)
        {
            _isAttacking = false;
        }

        private void SwitchAnimation(WatcherStateMachine stateMachine)
        {
            var randomAttack = Random.Range(0, _attackAnimations.Count);
            var animationSwitcher =
                new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, _attackAnimations[randomAttack]);
            animationSwitcher.SwitchAnimation();
        }
    }
}