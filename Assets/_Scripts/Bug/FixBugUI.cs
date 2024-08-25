using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Bug
{
    public class FixBugUI : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private void Fix(float lifetime)
        {
            slider.value = lifetime;
        }

        private void OnEnable()
        {
            FixBug.FixingBug += Fix;
        }

        private void OnDisable()
        {
            FixBug.FixingBug -= Fix;
        }
    }
}