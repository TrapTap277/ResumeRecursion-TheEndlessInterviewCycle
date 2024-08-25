using _Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy
{
    public class CrabChasing : MonoBehaviour, IEnemyMove
    {
        private InputReader _player;

        private const float SPEED = 10;

        private NavMeshAgent _navMeshAgent;

        private Animator _animator;

        private const string MOVE_ANIMATION = "Chasing";

        private IEnemyMove _moveType;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _player = FindObjectOfType<InputReader>();
        }

        public void Move()
        {
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(_animator, MOVE_ANIMATION);
            animationSwitcher.SwitchAnimation();
            _navMeshAgent.speed = SPEED;
            _navMeshAgent.SetDestination(_player.gameObject.transform.position);
        }
    }
}