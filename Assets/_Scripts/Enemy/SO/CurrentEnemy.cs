using _Scripts.Enemy.EnemyCreator;
using UnityEngine;

namespace _Scripts.Enemy.SO
{
    public class CurrentEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyStats enemyStats;

        [HideInInspector] public EnemyType type;
        [HideInInspector] public float health;
        [HideInInspector] public float speed;
        [HideInInspector] public float damage;
        [HideInInspector] public float attackRange;
        [HideInInspector] public float attackRadius;

        public void SetEnemy(EnemyStats enemyConfig)
        {
            enemyStats = enemyConfig;

            Initialize();
        }

        public void Initialize()
        {
            if (enemyStats == null)
            {
                Debug.LogError("EnemyStats не установлен в CurrentEnemy");
                return;
            }

            type = enemyStats.Type;
            health = enemyStats.Health;
            speed = enemyStats.Speed;
            damage = enemyStats.Damage;
            attackRange = enemyStats.AttackRange;
            attackRadius = enemyStats.AttackRadius;
        }
    }
}