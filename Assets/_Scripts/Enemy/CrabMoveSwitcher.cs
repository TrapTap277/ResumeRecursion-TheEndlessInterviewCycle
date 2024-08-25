using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class CrabMoveSwitcher : MonoBehaviour, IEnemyMove
    {
        private InputReader _player;

        private IEnemyMove _moveType;

        private void Awake()
        {
            _player = FindObjectOfType<InputReader>();
        }

        public void Move()
        {
            var distance = Vector3.Distance(gameObject.transform.position, _player.gameObject.transform.position);

            if (distance > 20)
                _moveType = gameObject.GetComponent<CrabPatrolling>();

            else
                _moveType = gameObject.GetComponent<CrabChasing>();

            _moveType.Move();
        }
    }
}