﻿using _Scripts.Enemy.EnemyCreator;
using UnityEngine;

namespace _Scripts.Enemy.SO
{
    [CreateAssetMenu(menuName = "Enemy")]
    public class EnemySo : ScriptableObject
    {
        [SerializeField] private float health;
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        [SerializeField] private float attackRange;
        [SerializeField] private float attackRadius;

        public float Health => health;
        public float Speed => speed;
        public float Damage => damage;
        public float AttackRange => attackRange;
        public float AttackRadius => attackRadius;
    }
}