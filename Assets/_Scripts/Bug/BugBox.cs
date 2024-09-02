using System.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Bug
{
    public class BugBox : MonoBehaviour
    {
        private const string PLAYER = "Player";

        private bool _clicked;
        private bool _startFixingKey;

        private async void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(PLAYER)) return;
            if (!_clicked) await WaitForSpaceKey();

            FixBug();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(PLAYER)) return;
            _clicked = false;
        }

        private async Task WaitForSpaceKey()
        {
            _startFixingKey = Input.GetKeyDown(KeyCode.E);
            while (!_startFixingKey) await Task.Yield();

            _clicked = true;
        }

        private void FixBug()
        {
            IFix fix = gameObject.GetComponent<FixBug>();
            fix.Fix();
        }
    }
}