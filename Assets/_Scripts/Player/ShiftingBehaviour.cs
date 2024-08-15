using UnityEngine;

namespace _Scripts.Player
{
    public class ShiftingBehaviour : MonoBehaviour, IMove
    {
        [SerializeField] private float moveSpeed = 2f;

        public void Move(Vector2 direction)
        {
            var movement = new Vector3(direction.x,0, direction.y) * (moveSpeed * Time.deltaTime);
            transform.Translate(movement, Space.Self);
        }
    }
}