using System.Collections;
using UnityEngine;

namespace _Scripts.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        private IAttack _attack;
        private IEnemyMove _enemyMove;
        private IDie _die;

        private float _timeToAttack;
        private string _player = "Player";

        private bool _isMoving;

        public void Construct(IAttack attack, IEnemyMove enemyMove, IDie die)
        {
            _attack = attack;
            _enemyMove = enemyMove;
            _die = die;
            _isMoving = true;
        }

        private void Update()
        {
            if (_isMoving) Move();
        }

        public void Die()
        {
            _die.Die(); // TOdo: Needs a new component Enemy Health
        }

        private void Attack()
        {
            _attack.Attack();
        }

        private void Move()
        {
            _enemyMove.Move();
        }

        private void OnTriggerStay(Collider other)
        {
            if (_timeToAttack <= 0 && other.CompareTag(_player))
            {
                _isMoving = false;
                Attack();
                _timeToAttack = Random.Range(5, 10);
            }

            if (_timeToAttack > 0)
            {
                StartCoroutine(RestoreMoving());
                _timeToAttack -= Time.deltaTime;
            }
        }

        private IEnumerator RestoreMoving()
        {
            yield return new WaitForSeconds(0.6f);
            _isMoving = true;
        }
    }
}