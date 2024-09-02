﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace _Scripts.Enemy.Health
{
    public abstract class HealthBase : MonoBehaviour, IShow
    {
        public static event Action<float> OnChangedDamage;
        public static event Action<bool> OnDied;
        public static event Action OnSetIsSomeoneDied;

        public float Health { get; private set; }
        protected readonly List<CanvasGroup> CanvasGroup = new List<CanvasGroup>();
        // protected TextMeshProUGUI HealthInPercents;
        protected Image FrontHealthBar;
        protected Image BackHealthBar;
        private static float _damageСoefficient;
        private const float MAX_HEALTH = 100;
        private const float CHIP_SPEED = 4f;
        private float _didDamage;
        private float _lerpTimer;
        private bool _isHasProtection;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            InitProperties();
        }

        public void Show()
        {
            foreach (var canvasGroup in CanvasGroup) canvasGroup.DOFade(1, 1);
        }

        private void Start()
        {
            Health = MAX_HEALTH;
            _damageСoefficient = 1f;
            Health = Mathf.Clamp(Health, 0, MAX_HEALTH);
        }

        protected abstract void InitProperties();


        public void TakeDamage(float damage)
        {
            OnDied?.Invoke(false);
            if (!_isHasProtection)
            {
                var damageСoefficient = damage * _damageСoefficient;
                Health -= damageСoefficient;
                _didDamage += damageСoefficient;
            }

            _lerpTimer = 0;

            if (Health <= 0) Died();

            SetHealth();
            HealthBarLerp();
        }

        public void RestoreHealth(float healthAmount)
        {
            Health += healthAmount;
            _lerpTimer = 0;
            SetHealth();
            HealthBarLerp();
        }

        private void ResetProperties()
        {
            _isHasProtection = false;
            _damageСoefficient = 1f;
        }

        protected void GetProtection()
        {
            _isHasProtection = true;
        }

        private static void TakeMoreDamage()
        {
            _damageСoefficient = Random.Range(1.1f, 2f);
        }

        protected virtual void Died()
        {
            OnSetIsSomeoneDied?.Invoke();
            OnDied?.Invoke(true);
            OnChangedDamage?.Invoke(_didDamage);
        }

        private void SetHealth()
        {
            Health = Mathf.Clamp(Health, 0, MAX_HEALTH);
        }

        private void HealthBarLerp()
        {
            var fillFront = FrontHealthBar.fillAmount;
            var fillBack = BackHealthBar.fillAmount;
            var valueFraction = Health / MAX_HEALTH;

            if (fillBack > valueFraction)
            {
                ChangeColor(Color.red);
                ChangeFillAmount(valueFraction, FrontHealthBar);
                StartCoroutine(SetFillWithLerp(fillBack, valueFraction, BackHealthBar));
            }

            if (fillFront < valueFraction)
            {
                ChangeColor(Color.green);
                ChangeFillAmount(valueFraction, BackHealthBar);
                StartCoroutine(SetFillWithLerp(fillFront, BackHealthBar.fillAmount, FrontHealthBar));
            }
        }

        private IEnumerator SetFillWithLerp(float fill, float value, Image healthBar)
        {
            _lerpTimer = 0f;
            while (_lerpTimer <= CHIP_SPEED)
            {
                yield return new WaitForEndOfFrame();
                _lerpTimer += Time.deltaTime * CHIP_SPEED;
                var percentComplete = _lerpTimer / CHIP_SPEED;
                percentComplete *= percentComplete;
                healthBar.fillAmount = Mathf.Lerp(fill, value, percentComplete);
                var percents = Mathf.RoundToInt(healthBar.fillAmount * 100).ToString();
                // HealthInPercents.text = $"{percents}%";
                SetHealth();
            }
        }

        private static void ChangeFillAmount(float valueFraction, Image healthBar)
        {
            healthBar.fillAmount = valueFraction;
        }

        private void ChangeColor(Color color)
        {
            BackHealthBar.color = color;
        }

        protected virtual void OnEnable()
        {
            // DamageGemItem.OnTakeMoreDamage += TakeMoreDamage;
            // ParticleCollision.OnResetedProperties += ResetProperties;
            // BaseShoot.OnResetedItems += ResetProperties;
        }

        protected virtual void OnDisable()
        {
            // DamageGemItem.OnTakeMoreDamage -= TakeMoreDamage;
            // ParticleCollision.OnResetedProperties -= ResetProperties;
            // BaseShoot.OnResetedItems -= ResetProperties;
        }
    }
}