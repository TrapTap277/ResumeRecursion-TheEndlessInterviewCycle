using UnityEngine;

namespace _Scripts.Enemy.SO
{
    public class CurrentEnemy : MonoBehaviour
    {
        [SerializeField] private EnemySo enemySo;

        [HideInInspector] public float health;
        [HideInInspector] public float speed;
        [HideInInspector] public float damage;
        [HideInInspector] public float attackRange;
        [HideInInspector] public float attackRadius;

        public void SetEnemy(EnemySo enemyConfig)
        {
            enemySo = enemyConfig;

            Initialize();
        }

        public void Initialize()
        {
            if (enemySo == null)
            {
                Debug.LogError("EnemySo не установлен в CurrentEnemy");
                return;
            }

            health = enemySo.Health;
            speed = enemySo.Speed;
            damage = enemySo.Damage;
            attackRange = enemySo.AttackRange;
            attackRadius = enemySo.AttackRadius;
        }
    }
}