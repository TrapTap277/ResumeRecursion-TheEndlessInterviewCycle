using System.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Bug
{
    public class BugBox : MonoBehaviour
    {
        private bool _clicked;

        private async void OnTriggerStay(Collider other)
        {
            if (!_clicked) await WaitForSpaceKey();

            IFix fix = gameObject.GetComponent<FixBug>();
            fix.Fix();
        }

        private void OnTriggerExit(Collider other)
        {
            _clicked = false;
        }

        private async Task WaitForSpaceKey()
        {
            while (!Input.GetKeyDown(KeyCode.E)) await Task.Yield();

            _clicked = true;
        }
    }
}