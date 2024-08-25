using _Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy
{
    public class CrabPatrolling : MonoBehaviour, IEnemyMove
    {
        private InputReader _player;

        private const float SPEED = 1;

        private NavMeshAgent _navMeshAgent;

        private Animator _animator;

        private const string MOVE_ANIMATION = "Patrolling";

        private IEnemyMove _moveType;

        private Vector3 _previousPoint;

        private bool _isRichPos;

        private float _dist;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _player = FindObjectOfType<InputReader>();
            _navMeshAgent.speed = SPEED;
        }

        public void Move()
        {
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(_animator, MOVE_ANIMATION);
            animationSwitcher.SwitchAnimation();

            var randomPoint = Random.insideUnitSphere * 5f;
            randomPoint += transform.position;

            _isRichPos = _dist < 1;
            _dist = Vector3.Distance(gameObject.transform.position, _previousPoint);


            if (NavMesh.SamplePosition(randomPoint, out var hit, 5f, NavMesh.AllAreas) && _isRichPos)
            {
                _previousPoint = hit.position;

                _navMeshAgent.SetDestination(hit.position);
                _navMeshAgent.speed = SPEED;
            }
        }
    }
}