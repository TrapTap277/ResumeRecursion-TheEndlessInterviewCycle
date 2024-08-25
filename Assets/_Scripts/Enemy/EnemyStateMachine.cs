using System;
using _Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy
{
    public class EnemyStateMachine : MonoBehaviour
    {
        public readonly EnemyAttacking Attacking = new EnemyAttacking();
        public readonly EnemyChasing Chasing = new EnemyChasing();
        public readonly EnemyPatrolling Patrolling = new EnemyPatrolling();
        public readonly EnemyDying Dying = new EnemyDying();

        [HideInInspector] public InputReader player;

        [HideInInspector] public NavMeshAgent navMeshAgent;

        [HideInInspector] public Animator animator;

        private EnemyBaseState _currentState;

        private void Start()
        {
            animator = GetComponent<Animator>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            player = FindObjectOfType<InputReader>();

            _currentState = Patrolling;
            _currentState.Enter(this);
        }

        private void Update()
        {
            _currentState.Update(this);
        }

        public void SwitchState(EnemyBaseState baseState)
        {
            _currentState.Exit(this);
            _currentState = baseState;
            _currentState.Enter(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.gameObject.CompareTag("Player")) return;
            if (_currentState != Dying) SwitchState(Attacking);
        }

        private void OnTriggerExit(Collider other)
        {
            if(!other.gameObject.CompareTag("Player")) return;
            if (_currentState != Dying) SwitchState(Chasing);
        }
    }
}