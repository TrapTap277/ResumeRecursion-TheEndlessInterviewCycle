using _Scripts.Enemy.Health;
using _Scripts.Enemy.SO;
using UnityEngine;
using Zenject;

namespace _Scripts.Enemy.AttackLogic
{
    public abstract class EnemyAttack : MonoBehaviour
    {
        [SerializeField] protected LayerMask _playerMask;

        protected CurrentEnemy Enemy;
        protected HealthBase Player;

        [Inject]
        public void Construct(CurrentEnemy enemy, HealthBase player)
        {
            Enemy = enemy;
            Player = player;
        }

        public void Attack()
        {
            var forward = transform.forward;
            var capsuleStart = transform.position + Vector3.up + forward * Enemy.attackRadius;
            var capsuleEnd = capsuleStart + forward * (Enemy.attackRange - Enemy.attackRadius * 2);

            var hits = Physics.CapsuleCastAll(capsuleStart, capsuleEnd, Enemy.attackRadius, forward,
                Enemy.attackRange, _playerMask);

            if (hits.Length > 0)
            {
                Player.TakeDamage(Enemy.damage);
            }
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var capsuleStart = transform.position + Vector3.up + transform.forward * Enemy.attackRadius;
            var capsuleEnd = capsuleStart + transform.forward * (Enemy.attackRange - Enemy.attackRadius * 2);

            Gizmos.DrawWireSphere(capsuleStart, Enemy.attackRadius);
            Gizmos.DrawWireSphere(capsuleEnd, Enemy.attackRadius);
            Gizmos.DrawLine(capsuleStart + Vector3.up * Enemy.attackRadius,
                capsuleEnd + Vector3.up * Enemy.attackRadius);
            Gizmos.DrawLine(capsuleStart - Vector3.up * Enemy.attackRadius,
                capsuleEnd - Vector3.up * Enemy.attackRadius);
            Gizmos.DrawLine(capsuleStart + Vector3.right * Enemy.attackRadius,
                capsuleEnd + Vector3.right * Enemy.attackRadius);
            Gizmos.DrawLine(capsuleStart - Vector3.right * Enemy.attackRadius,
                capsuleEnd - Vector3.right * Enemy.attackRadius);
        }
    }
}