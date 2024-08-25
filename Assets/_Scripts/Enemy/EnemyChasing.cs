using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyChasing : EnemyBaseState
    {
        private const string CHASE_ANIMATION = "Chasing";
        private const float UPDATE_RATE = 0.1f;
        private const float ROTATION_SPEED = 5f;
        private const float CHASE_SPEED = 3.5f;
        private float _nextUpdateTime;
        private const float CHASING_RADIUS = 30;

        public override void Enter(EnemyStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.speed = CHASE_SPEED;
            SetAnimation(stateMachine);
        }

        public override void Update(EnemyStateMachine stateMachine)
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

        private void UpdateChaseLogic(EnemyStateMachine stateMachine)
        {
            if (stateMachine.player != null)
            {
                var playerPosition = stateMachine.player.transform.position;
                stateMachine.navMeshAgent.SetDestination(playerPosition);
            }
        }

        private void RotateTowardsPlayer(EnemyStateMachine stateMachine)
        {
            if (stateMachine.player != null)
            {
                var direction = (stateMachine.player.transform.position - stateMachine.transform.position).normalized;
                var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, lookRotation,
                    Time.deltaTime * ROTATION_SPEED);
            }
        }

        private static void SetAnimation(EnemyStateMachine stateMachine)
        {
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(stateMachine.animator, CHASE_ANIMATION);
            animationSwitcher.SwitchAnimation();
        }

        public override void Exit(EnemyStateMachine stateMachine)
        {
            stateMachine.navMeshAgent.ResetPath();
        }
    }
}