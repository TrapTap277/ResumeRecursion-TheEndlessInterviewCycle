using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Enemy.Health
{
    public class EnemyHealth : HealthBase
    {
        public new static event Action OnDied;

        [SerializeField] private CanvasGroup healthBar;
        [SerializeField] private Image frontHealthBar;
        [SerializeField] private Image backHealthBar;

        protected override void InitProperties()
        {
            FrontHealthBar = frontHealthBar;
            BackHealthBar = backHealthBar;
            CanvasGroup.Add(healthBar);
        }

        protected override void Died()
        {
            DieManager.AddEnemyDies();
            OnDied?.Invoke();
            base.Died();
        }

        protected override void OnEnable()
        {
            // HealGemItem.OnHealedEnemy += RestoreHealth;
            // ProtectionGemItem.OnGivenProtectionToEnemy += GetProtection;
            // base.OnEnable();
        }

        protected override void OnDisable()
        {
            // HealGemItem.OnHealedEnemy -= RestoreHealth;
            // ProtectionGemItem.OnGivenProtectionToEnemy -= GetProtection;
            // base.OnDisable();
        }
    }
}