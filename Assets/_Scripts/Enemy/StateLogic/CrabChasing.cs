using UnityEngine;

namespace _Scripts.Enemy.StateLogic
{
    public class CrabChasing : CrabBaseState
    {
        private const string CHASE_ANIMATION = "Chasing";
        private const float UPDATE_RATE = 0.1f;
        private const float ROTATION_SPEED = 5f;
        private const float CHASE_SPEED = 3.5f;
        private float _nextUpdateTime;
        private const float CHASING_RADIUS = 30;

        public override void Enter(CrabStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.speed = CHASE_SPEED;
            SetAnimation(stateMachine);
        }

        public override void Update(CrabStateMachine stateMachine)
        {
            if (Time.time >= _nextUpdateTime)
            {
                UpdateChaseLogic(stateMachine);
                _nextUpdateTime = Time.time + UPDATE_RATE;
            }

            RotateTowardsPlayer(stateMachine);

            if (Vector3.Distance(stateMachine.transform.position, stateMachine.player.transform.position) >
                CHASING_RADIUS)
                stateMachine.SwitchState(stateMachine.Patrolling);
        }

        private void UpdateChaseLogic(CrabStateMachine stateMachine)
        {
            if (stateMachine.player != null)
            {
                var playerPosition = stateMachine.player.transform.position;
                stateMachine.navMeshAgent.SetDestination(playerPosition);
            }
        }

        private void RotateTowardsPlayer(CrabStateMachine stateMachine)
        {
            if (stateMachine.player != null)
            {
                var direction = (stateMachine.player.transform.position - stateMachine.transform.position).normalized;
                var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, lookRotation,
                    Time.deltaTime * ROTATION_SPEED);
            }
        }

        private void SetAnimation(CrabStateMachine stateMachine)
        {
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, CHASE_ANIMATION);
            animationSwitcher.SwitchAnimation();
        }

        public override void Exit(CrabStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.ResetPath();
        }
    }

    public class GolemChasing : GolemBaseState
    {
        private const string CHASE_ANIMATION = "Chasing";
        private const float UPDATE_RATE = 0.1f;
        private const float ROTATION_SPEED = 5f;
        private const float CHASE_SPEED = 3.5f;
        private float _nextUpdateTime;
        private const float CHASING_RADIUS = 30;

        public override void Enter(GolemStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.speed = CHASE_SPEED;
            SetAnimation(stateMachine);
        }

        public override void Update(GolemStateMachine stateMachine)
        {
            if (Time.time >= _nextUpdateTime)
            {
                UpdateChaseLogic(stateMachine);
                _nextUpdateTime = Time.time + UPDATE_RATE;
            }

            RotateTowardsPlayer(stateMachine);

            if (Vector3.Distance(stateMachine.transform.position, stateMachine.player.transform.position) >
                CHASING_RADIUS)
                stateMachine.SwitchState(stateMachine.Patrolling);
        }

        private void UpdateChaseLogic(GolemStateMachine stateMachine)
        {
            if (stateMachine.player != null)
            {
                var playerPosition = stateMachine.player.transform.position;
                stateMachine.navMeshAgent.SetDestination(playerPosition);
            }
        }

        private void RotateTowardsPlayer(GolemStateMachine stateMachine)
        {
            if (stateMachine.player != null)
            {
                var direction = (stateMachine.player.transform.position - stateMachine.transform.position).normalized;
                var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, lookRotation,
                    Time.deltaTime * ROTATION_SPEED);
            }
        }

        private static void SetAnimation(GolemStateMachine stateMachine)
        {
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, CHASE_ANIMATION);
            animationSwitcher.SwitchAnimation();
        }

        public override void Exit(GolemStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.ResetPath();
        }
    }

    public class WatcherChasing : WatcherBaseState
    {
        private const string CHASE_ANIMATION = "Chasing";
        private const float UPDATE_RATE = 0.1f;
        private const float ROTATION_SPEED = 5f;
        private const float CHASE_SPEED = 3.5f;
        private float _nextUpdateTime;
        private const float CHASING_RADIUS = 30;

        public override void Enter(WatcherStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.speed = CHASE_SPEED;
            SetAnimation(stateMachine);
        }

        public override void Update(WatcherStateMachine stateMachine)
        {
            if (Time.time >= _nextUpdateTime)
            {
                UpdateChaseLogic(stateMachine);
                _nextUpdateTime = Time.time + UPDATE_RATE;
            }

            RotateTowardsPlayer(stateMachine);

            if (Vector3.Distance(stateMachine.transform.position, stateMachine.player.transform.position) >
                CHASING_RADIUS)
                stateMachine.SwitchState(stateMachine.Patrolling);
        }

        private void UpdateChaseLogic(WatcherStateMachine stateMachine)
        {
            if (stateMachine.player != null)
            {
                var playerPosition = stateMachine.player.transform.position;
                stateMachine.navMeshAgent.SetDestination(playerPosition);
            }
        }

        private void RotateTowardsPlayer(WatcherStateMachine stateMachine)
        {
            if (stateMachine.player != null)
            {
                var direction = (stateMachine.player.transform.position - stateMachine.transform.position).normalized;
                var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, lookRotation,
                    Time.deltaTime * ROTATION_SPEED);
            }
        }

        private static void SetAnimation(WatcherStateMachine stateMachine)
        {
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, CHASE_ANIMATION);
            animationSwitcher.SwitchAnimation();
        }

        public override void Exit(WatcherStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.ResetPath();
        }
    }
}