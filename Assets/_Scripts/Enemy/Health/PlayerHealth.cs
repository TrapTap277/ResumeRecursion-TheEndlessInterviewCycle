using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Enemy.Health
{
    public class PlayerHealth : HealthBase
    {
        public new static event Action OnDied;

        [SerializeField] private CanvasGroup healthBar;
        // [SerializeField] private TextMeshProUGUI healthInPercents;
        [SerializeField] private Image frontHealthBar;
        [SerializeField] private Image backHealthBar;

        protected override void InitProperties()
        {
            // HealthInPercents = healthInPercents;
            FrontHealthBar = frontHealthBar;
            BackHealthBar = backHealthBar;
            CanvasGroup.Add(healthBar);
        }

        protected override void Died()
        {
            DieManager.AddPlayerDies();
            OnDied?.Invoke();

            base.Died();
        }

        protected override void OnEnable()
        {
            // HealGemItem.OnHealedPlayer += RestoreHealth;
            // ProtectionGemItem.OnGivenProtectionToPlayer += GetProtection;
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            // HealGemItem.OnHealedPlayer -= RestoreHealth;
            // ProtectionGemItem.OnGivenProtectionToPlayer -= GetProtection;
            base.OnDisable();
        }
    }
}