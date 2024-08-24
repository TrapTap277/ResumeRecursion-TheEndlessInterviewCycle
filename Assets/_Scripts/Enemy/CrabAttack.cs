using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy
{
    public class CrabAttack : MonoBehaviour, IAttack
    {
        private Animator _animator;

        private const string ATTACK_ANIMATION = "Attack";
        private const string ATTACK_ANIMATION1 = "Attack1";
        private const string ATTACK_ANIMATION2 = "Attack2";
        private const string ATTACK_ANIMATION3 = "Attack3";
        private const string ATTACK_ANIMATION4 = "Attack4";

        private readonly List<string> _attackAnimations = new List<string>();

        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _attackAnimations.Add(ATTACK_ANIMATION);
            _attackAnimations.Add(ATTACK_ANIMATION1);
            _attackAnimations.Add(ATTACK_ANIMATION2);
            _attackAnimations.Add(ATTACK_ANIMATION3);
            _attackAnimations.Add(ATTACK_ANIMATION4);
        }

        public void Attack()
        {
            var randomAttack = Random.Range(0, _attackAnimations.Count);
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(_animator, _attackAnimations[randomAttack]);
            animationSwitcher.SwitchAnimation();

            _navMeshAgent.speed = 0;
            // Todo Deal damage to Player
        }
    }
}