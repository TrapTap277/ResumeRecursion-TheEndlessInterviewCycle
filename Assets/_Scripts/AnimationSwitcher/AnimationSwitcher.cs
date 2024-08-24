using UnityEngine;

namespace _Scripts.AnimationSwitcher
{
    public class AnimationSwitcher
    {
        private readonly Animator _animator;
        private int _animationName;

        public AnimationSwitcher(Animator animator, string animationName)
        {
            _animator = animator;

            ConvertToHash(animationName);
        }

        public void SwitchAnimation()
        {
            _animator.CrossFade(_animationName, 0);
        }
        
        private void ConvertToHash(string animationName)
        {
            _animationName = Animator.StringToHash(animationName);
        }
    }
}