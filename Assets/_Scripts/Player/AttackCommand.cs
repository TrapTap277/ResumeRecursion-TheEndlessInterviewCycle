namespace _Scripts.Player
{
    public class AttackCommand
    {
        public void Execute(IAttack attack)
        {
            attack.Attack();
        }
    }
}