using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy.StateLogic
{
    public class CrabPatrolling : CrabBaseState
    {
        private const string MOVE_ANIMATION = "Patrolling";
        private const string IDLE_ANIMATION = "Idle";
        private const float PATROL_RADIUS = 30f;
        private const float MIN_DISTANCE_TO_POINT = 1f;
        private const float WAIT_TIME = 2f;
        private Vector3 _initialPosition;
        private Vector3 _currentDestination;
        private float _waitTimer;

        public override void Enter(CrabStateMachine stateMachine)
        {
            _initialPosition = stateMachine.transform.position;
            SetNewDestination(stateMachine);
            SetAnimation(stateMachine, MOVE_ANIMATION);
        }

        public override void Update(CrabStateMachine stateMachine)
        {
            if (Vector3.Distance(stateMachine.transform.position, _currentDestination) < MIN_DISTANCE_TO_POINT)
            {
                if (_waitTimer <= 0)
                {
                    SetNewDestination(stateMachine);
                    SetAnimation(stateMachine, MOVE_ANIMATION);
                }
                else
                {
                    _waitTimer -= Time.deltaTime;
                    stateMachine.navMeshAgent.isStopped = true;

                    SetAnimation(stateMachine, IDLE_ANIMATION);
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

        private void SetNewDestination(CrabStateMachine stateMachine)
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

        private static void SetAnimation(CrabStateMachine stateMachine, string animation)
        {
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, animation);
            animationSwitcher.SwitchAnimation();
        }

        public override void Exit(CrabStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.isStopped = false;
        }
    }

    public class GolemPatrolling : GolemBaseState
    {
        private const string MOVE_ANIMATION = "Patrolling";
        private const string IDLE_ANIMATION = "Idle";
        private const float PATROL_RADIUS = 30f;
        private const float MIN_DISTANCE_TO_POINT = 1f;
        private const float WAIT_TIME = 5f;
        private Vector3 _initialPosition;
        private Vector3 _currentDestination;
        private float _waitTimer;

        public override void Enter(GolemStateMachine stateMachine)
        {
            _initialPosition = stateMachine.transform.position;
            SetNewDestination(stateMachine);
            SetAnimation(stateMachine, MOVE_ANIMATION);
        }

        public override void Update(GolemStateMachine stateMachine)
        {
            if (Vector3.Distance(stateMachine.transform.position, _currentDestination) < MIN_DISTANCE_TO_POINT)
            {
                if (_waitTimer <= 0)
                {
                    SetNewDestination(stateMachine);
                    SetAnimation(stateMachine, MOVE_ANIMATION);
                }
                else
                {
                    _waitTimer -= Time.deltaTime;
                    stateMachine.navMeshAgent.isStopped = true;

                    SetAnimation(stateMachine, IDLE_ANIMATION);
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

        private void SetNewDestination(GolemStateMachine stateMachine)
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

        private void SetAnimation(GolemStateMachine stateMachine, string animation)
        {
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, animation);
            animationSwitcher.SwitchAnimation();
        }

        public override void Exit(GolemStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.isStopped = false;
        }
    }

    public class WatcherPatrolling : WatcherBaseState
    {
        private const string MOVE_ANIMATION = "Patrolling";
        private const string IDLE_ANIMATION = "Idle";
        private const float PATROL_RADIUS = 30f;
        private const float MIN_DISTANCE_TO_POINT = 1f;
        private const float WAIT_TIME = 3f;
        private Vector3 _initialPosition;
        private Vector3 _currentDestination;
        private float _waitTimer;

        public override void Enter(WatcherStateMachine stateMachine)
        {
            _initialPosition = stateMachine.transform.position;
            SetNewDestination(stateMachine);
            SetAnimation(stateMachine, MOVE_ANIMATION);
        }

        public override void Update(WatcherStateMachine stateMachine)
        {
            if (Vector3.Distance(stateMachine.transform.position, _currentDestination) < MIN_DISTANCE_TO_POINT)
            {
                if (_waitTimer <= 0)
                {
                    SetNewDestination(stateMachine);
                    SetAnimation(stateMachine, MOVE_ANIMATION);
                }
                else
                {
                    _waitTimer -= Time.deltaTime;
                    stateMachine.navMeshAgent.isStopped = true;

                    SetAnimation(stateMachine, IDLE_ANIMATION);
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

        private void SetNewDestination(WatcherStateMachine stateMachine)
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

        private static void SetAnimation(WatcherStateMachine stateMachine, string animation)
        {
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, animation);
            animationSwitcher.SwitchAnimation();
        }

        public override void Exit(WatcherStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.isStopped = false;
        }
    }
}