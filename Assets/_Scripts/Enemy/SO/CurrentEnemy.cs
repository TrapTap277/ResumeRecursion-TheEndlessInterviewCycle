using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Enemy.SO
{
    public class CurrentEnemy : MonoBehaviour, IInitializable
    {
        [SerializeField] private EnemySo enemySo;
        [SerializeField] private SkinnedMeshRenderer meshRenderer;

        [HideInInspector] public GameObject prefab;
        [HideInInspector] public float health;
        [HideInInspector] public float speed;
        [HideInInspector] public float damage;
        [HideInInspector] public float attackRange;
        [HideInInspector] public float attackRadius;

        [Inject]
        private void Construct(EnemySo enemyConfig)
        {
            enemySo = enemyConfig;
        }

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            if (enemySo == null)
            {
                Debug.LogError("EnemySo не установлен в CurrentEnemy");
                return;
            }

            meshRenderer.material = enemySo.Material;

            prefab = enemySo.Prefab;
            health = enemySo.Health;
            speed = enemySo.Speed;
            damage = enemySo.Damage;
            attackRange = enemySo.AttackRange;
            attackRadius = enemySo.AttackRadius;
        }
    }
}