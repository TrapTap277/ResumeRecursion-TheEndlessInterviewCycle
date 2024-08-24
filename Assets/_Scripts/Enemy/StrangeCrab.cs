using UnityEngine;

namespace _Scripts.Enemy
{
    public class StrangeCrab : Enemy
    {
        public Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
    }
}