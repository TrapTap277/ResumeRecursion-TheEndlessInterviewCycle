using System.Collections;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class CrabDie : MonoBehaviour, IDie
    {
        private const string DIE = "Die";
        private const float TIME_TO_DIE = 3;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Die()
        {
            StartCoroutine(SetDieAnimation());
            Debug.Log("Die");
        }

        private IEnumerator SetDieAnimation()
        {
            var animationSwitcher = new AnimationSwitcher.AnimationSwitcher(_animator, DIE);
            animationSwitcher.SwitchAnimation();

            yield return new WaitForSeconds(TIME_TO_DIE);

            Destroy(gameObject);
        }
    }
}