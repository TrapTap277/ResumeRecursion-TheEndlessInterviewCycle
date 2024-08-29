using _Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy.StateLogic
{
    public class GolemStateMachine : MonoBehaviour
    {
        public readonly GolemAttacking Attacking = new GolemAttacking();
        public readonly GolemChasing Chasing = new GolemChasing();
        public readonly GolemPatrolling Patrolling = new GolemPatrolling();
        public readonly GolemDying Dying = new GolemDying();
        
        private GolemBaseState _currentState;

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

        public void SwitchState(GolemBaseState baseState)
        {
            _currentState.Exit(this);
            _currentState = baseState;
            _currentState.Enter(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (_currentState != Dying) SwitchState(Attacking);
            
            Debug.LogError("entered");
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (_currentState != Dying) SwitchState(Chasing);
        }
    }
}