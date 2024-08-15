using UnityEngine;

namespace _Scripts.Player
{
    public class AttackBehaviour : MonoBehaviour, IAttack
    {
        public void Attack()
        {
            Debug.Log("Attack");
        }
    }
}