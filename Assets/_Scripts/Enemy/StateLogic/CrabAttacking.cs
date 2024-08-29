using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Enemy.StateLogic
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
        private Coroutine _attackCoroutine;

        private float _attackStopTime;

        public override void Enter(CrabStateMachine stateMachine)
        {
            _attackAnimations.Add(ATTACK_ANIMATION);
            _attackAnimations.Add(ATTACK_ANIMATION1);
            _attackAnimations.Add(ATTACK_ANIMATION2);
            _attackAnimations.Add(ATTACK_ANIMATION3);
            _attackAnimations.Add(ATTACK_ANIMATION4);

            _isAttacking = true;

            if (_attackCoroutine != null) stateMachine.StopAllCoroutines();

            _attackCoroutine = stateMachine.StartCoroutine(AttackAnimation(stateMachine));
        }

        private IEnumerator AttackAnimation(CrabStateMachine stateMachine)
        {
            while (_isAttacking)
            {
                SwitchAnimation(stateMachine);
                yield return new WaitForSeconds(_attackStopTime);
            }
        }

        public override void Update(CrabStateMachine stateMachine)
        {
            if (_isAttacking) Rotate(stateMachine);
        }

        private static void Rotate(CrabStateMachine stateMachine)
        {
            var direction = (stateMachine.player.transform.position - stateMachine.transform.position).normalized;
            var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            stateMachine.transform.rotation =
                Quaternion.Slerp(stateMachine.transform.rotation, lookRotation, Time.deltaTime * 2);
        }

        public override void Exit(CrabStateMachine stateMachine)
        {
            _isAttacking = false;
            if (_attackCoroutine != null) stateMachine.StopAllCoroutines();
            _attackCoroutine = null;
        }

        private void SwitchAnimation(CrabStateMachine stateMachine)
        {
            var randomAttack = Random.Range(0, _attackAnimations.Count);
            var animationSwitcher =
                new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, _attackAnimations[randomAttack]);
            animationSwitcher.SwitchAnimation();
            _attackStopTime = animationSwitcher.GetAnimationDuration();
        }
    }

    public class GolemAttacking : GolemBaseState
    {
        private const string ATTACK_ANIMATION = "Attack";
        private const string ATTACK_ANIMATION1 = "Attack1";
        private const string ATTACK_ANIMATION2 = "Attack2";

        private readonly List<string> _attackAnimations = new List<string>();

        private bool _isAttacking;
        private Coroutine _attackCoroutine;

        private float _attackStopTime;

        public override void Enter(GolemStateMachine stateMachine)
        {
            _attackAnimations.Add(ATTACK_ANIMATION);
            _attackAnimations.Add(ATTACK_ANIMATION1);
            _attackAnimations.Add(ATTACK_ANIMATION2);

            _isAttacking = true;

            if (_attackCoroutine != null) stateMachine.StopAllCoroutines();

            _attackCoroutine = stateMachine.StartCoroutine(AttackAnimation(stateMachine));
        }

        private IEnumerator AttackAnimation(GolemStateMachine stateMachine)
        {
            while (_isAttacking)
            {
                SwitchAnimation(stateMachine);
                yield return new WaitForSeconds(_attackStopTime);
            }
        }

        public override void Update(GolemStateMachine stateMachine)
        {
            if (_isAttacking) Rotate(stateMachine);
        }

        private static void Rotate(GolemStateMachine stateMachine)
        {
            var direction = (stateMachine.player.transform.position - stateMachine.transform.position).normalized;
            var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            stateMachine.transform.rotation =
                Quaternion.Slerp(stateMachine.transform.rotation, lookRotation, Time.deltaTime * 2);
        }

        public override void Exit(GolemStateMachine stateMachine)
        {
            _isAttacking = false;
            if (_attackCoroutine != null) stateMachine.StopAllCoroutines();
            _attackCoroutine = null;
        }

        private void SwitchAnimation(GolemStateMachine stateMachine)
        {
            var randomAttack = Random.Range(0, _attackAnimations.Count);
            var animationSwitcher =
                new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, _attackAnimations[randomAttack]);
            animationSwitcher.SwitchAnimation();
            _attackStopTime = animationSwitcher.GetAnimationDuration();
        }
    }

    public class WatcherAttacking : WatcherBaseState
    {
        private const string ATTACK_ANIMATION = "Attack";
        private const string ATTACK_ANIMATION1 = "Attack1";

        private readonly List<string> _attackAnimations = new List<string>();

        private bool _isAttacking;
        private Coroutine _attackCoroutine;

        private float _attackStopTime;

        public override void Enter(WatcherStateMachine stateMachine)
        {
            _attackAnimations.Add(ATTACK_ANIMATION);
            _attackAnimations.Add(ATTACK_ANIMATION1);

            _isAttacking = true;

            if (_attackCoroutine != null) stateMachine.StopAllCoroutines();

            _attackCoroutine = stateMachine.StartCoroutine(AttackAnimation(stateMachine));
        }

        private IEnumerator AttackAnimation(WatcherStateMachine stateMachine)
        {
            while (_isAttacking)
            {
                SwitchAnimation(stateMachine);
                yield return new WaitForSeconds(_attackStopTime);
            }
        }

        public override void Update(WatcherStateMachine stateMachine)
        {
            if (_isAttacking) Rotate(stateMachine);
        }

        private static void Rotate(WatcherStateMachine stateMachine)
        {
            var direction = (stateMachine.player.transform.position - stateMachine.transform.position).normalized;
            var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            stateMachine.transform.rotation =
                Quaternion.Slerp(stateMachine.transform.rotation, lookRotation, Time.deltaTime * 2);
        }

        public override void Exit(WatcherStateMachine stateMachine)
        {
            _isAttacking = false;
            if (_attackCoroutine != null) stateMachine.StopAllCoroutines();
            _attackCoroutine = null;
        }

        private void SwitchAnimation(WatcherStateMachine stateMachine)
        {
            var randomAttack = Random.Range(0, _attackAnimations.Count);
            var animationSwitcher =
                new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, _attackAnimations[randomAttack]);
            animationSwitcher.SwitchAnimation();
            _attackStopTime = animationSwitcher.GetAnimationDuration();
        }
    }
}