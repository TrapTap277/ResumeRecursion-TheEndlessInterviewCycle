namespace _Scripts.Player
{
    public class JumpCommand
    {
        public void Execute(IJump jump)
        {
            jump.Jump();
        }
    }
}