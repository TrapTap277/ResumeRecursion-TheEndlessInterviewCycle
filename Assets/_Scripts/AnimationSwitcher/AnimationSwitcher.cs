using UnityEngine;

namespace _Scripts.AnimationSwitcher
{
    public class AnimationSwitcher
    {
        private readonly Animator _animator;
        private int _animationName;

        private AnimationClip _clip;

        public AnimationSwitcher(Animator animator, string animationName)
        {
            _animator = animator;

            ConvertToHash(animationName);
        }

        public void SwitchAnimation()
        {
            _animator.CrossFade(_animationName, 0);
        }

        public float GetAnimationDuration()
        {
            var clipInfo = _animator.GetCurrentAnimatorClipInfo(0);

            return clipInfo.Length > 0 ? clipInfo[0].clip.length : 0f;
        }

        private void ConvertToHash(string animationName)
        {
            _animationName = Animator.StringToHash(animationName);
        }
    }
}