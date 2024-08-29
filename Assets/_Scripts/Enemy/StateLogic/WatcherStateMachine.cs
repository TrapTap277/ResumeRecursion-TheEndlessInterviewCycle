using _Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy.StateLogic
{
    public class WatcherStateMachine : MonoBehaviour
    {
        public readonly WatcherAttacking Attacking = new WatcherAttacking();
        public readonly WatcherChasing Chasing = new WatcherChasing();
        public readonly WatcherPatrolling Patrolling = new WatcherPatrolling();
        public readonly WatcherDying Dying = new WatcherDying();

        private WatcherBaseState _currentState;

        [HideInInspector] public InputReader player;
        [HideInInspector] public NavMeshAgent navMeshAgent;
        [HideInInspector] public Animator animator;

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

        public void SwitchState(WatcherBaseState baseState)
        {
            _currentState.Exit(this);
            _currentState = baseState;
            _currentState.Enter(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (_currentState != Dying) SwitchState(Attacking);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (_currentState != Dying) SwitchState(Chasing);
        }
    }
}