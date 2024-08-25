using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        private IAttack _attack;
        private IEnemyMove _enemyMove;
        private IDie _die;

        private float _timeToAttack;
        private const string PLAYER = "Player";

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
            if (_timeToAttack <= 0 && other.CompareTag(PLAYER))
            {
                _isMoving = false;
                _timeToAttack = Random.Range(3, 5);
            }

            if (_timeToAttack > 0)
            {
                StartCoroutine(RestoreMoving());
                _timeToAttack -= Time.deltaTime;
            }
        }

        private IEnumerator RestoreMoving()
        {
            Attack();
            yield return new WaitForSeconds(1f);
            _isMoving = true;
        }
    }
}