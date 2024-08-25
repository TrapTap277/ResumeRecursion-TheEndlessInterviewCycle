using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy
{
    public class EnemyPatrolling : EnemyBaseState
    {
        private const string MOVE_ANIMATION = "Patrolling";
        private const float PATROL_RADIUS = 30f;
        private const float MIN_DISTANCE_TO_POINT = 1f;
        private const float WAIT_TIME = 2f;
        private Vector3 _initialPosition;
        private Vector3 _currentDestination;
        private float _waitTimer;

        public override void Enter(EnemyStateMachine stateMachine)
        {
            _initialPosition = stateMachine.transform.position;
            SetNewDestination(stateMachine);
            SetAnimation(stateMachine);
        }

        public override void Update(EnemyStateMachine stateMachine)
        {
            if (Vector3.Distance(stateMachine.transform.position, _currentDestination) < MIN_DISTANCE_TO_POINT)
            {
                if (_waitTimer <= 0)
                {
                    SetNewDestination(stateMachine);
                }
                else
                {
                    _waitTimer -= Time.deltaTime;
                    stateMachine.navMeshAgent.isStopped = true;
                    // Здесь можно добавить анимацию ожидания или осмотра
                }
            }
            else
            {
                stateMachine.navMeshAgent.isStopped = false;
            }

            if (Vector3.Distance(stateMachine.transform.position, stateMachine.player.transform.position) <
                PATROL_RADIUS)
                stateMachine.SwitchState(stateMachine.Chasing);
        }

        private void SetNewDestination(EnemyStateMachine stateMachine)
        {
            var randomDirection = Random.insideUnitSphere * PATROL_RADIUS;
            randomDirection += _initialPosition;
            if (NavMesh.SamplePosition(randomDirection, out var hit, PATROL_RADIUS, NavMesh.AllAreas))
            {
                _currentDestination = hit.position;
                stateMachine.navMeshAgent.SetDestination(_currentDestination);
                _waitTimer = WAIT_TIME;
            }
        }

        private static void SetAnimation(EnemyStateMachine stateMachine)
        {
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, MOVE_ANIMATION);
            animationSwitcher.SwitchAnimation();
        }

        public override void Exit(EnemyStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.isStopped = false;
        }
    }
}