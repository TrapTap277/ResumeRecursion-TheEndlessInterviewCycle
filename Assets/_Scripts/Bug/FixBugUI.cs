using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Bug
{
    public class FixBugUI : MonoBehaviour
    {
        private Slider _slider;

        [Inject]
        public void Construct(Slider slider)
        {
            _slider = slider;
        }

        private void OnFixing(float lifetime)
        {
            _slider.value = lifetime;
        }

        private void OnEnable()
        {
            FixBug.OnFixingBug += OnFixing;
        }

        private void OnDisable()
        {
            FixBug.OnFixingBug -= OnFixing;
        }
    }
}