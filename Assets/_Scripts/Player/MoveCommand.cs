using UnityEngine;

namespace _Scripts.Player
{
    public class MoveCommand
    {
        public void Execute(IMove move, Vector2 direction)
        {
            move.Move(direction);
        }
    }
}