using UnityEngine;

namespace _Scripts.Player
{
    public class CameraCommand
    {
        public void Execute(IMove moveCamera, Vector2 direction)
        {
            moveCamera?.Move(direction);
        }
    }
}