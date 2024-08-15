using UnityEngine;

namespace _Scripts.Player
{
    public class JumpBehaviour : MonoBehaviour, IJump
    {
        private Rigidbody _rb;

        private const float FORCE = 5;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void Jump()
        {
            _rb.AddForce(Vector3.up * FORCE, ForceMode.Impulse);
        }
    }
}