using _Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy
{
    public class CrabMove : MonoBehaviour, IEnemyMove
    {
        private InputReader _player;

        private const float SPEED = 10;

        private NavMeshAgent _navMeshAgent;

        private Animator _animator;

        private const string MOVE_ANIMATION = "Walk";

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _player = FindObjectOfType<InputReader>();
        }

        private void Start()
        {
            _navMeshAgent.speed = SPEED;
        }

        public void Move()
        {
            _navMeshAgent.speed = SPEED;
            
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(_animator, MOVE_ANIMATION);
            animationSwitcher.SwitchAnimation();
            _navMeshAgent.SetDestination(_player.gameObject.transform.position);
        }
    }
}