using _Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy
{
    public class CrabStateMachine : MonoBehaviour
    {
        public readonly CrabAttacking Attacking = new CrabAttacking();
        public readonly CrabChasing Chasing = new CrabChasing();
        public readonly CrabPatrolling Patrolling = new CrabPatrolling();
        public readonly CrabDying Dying = new CrabDying();
        
        private CrabBaseState _currentState;

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

        public void SwitchState(CrabBaseState baseState)
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