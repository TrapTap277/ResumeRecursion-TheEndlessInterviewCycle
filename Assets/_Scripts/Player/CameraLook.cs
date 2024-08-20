using UnityEngine;

namespace _Scripts.Player
{
    public class CameraLook : MonoBehaviour, IMove
    {
        [SerializeField] private float stopFactor;
        [SerializeField] private Transform playerBody; 

        private float _xRotation;

        // private void Start()
        // {
        //     Cursor.lockState = CursorLockMode.Locked;
        //     Cursor.visible = false;
        // }

        public void Move(Vector2 direction)
        {
            var mouseX = direction.x * stopFactor;
            var mouseY = direction.y * stopFactor;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }

        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}