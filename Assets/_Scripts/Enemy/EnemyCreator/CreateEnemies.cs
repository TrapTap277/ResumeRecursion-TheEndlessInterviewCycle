using System.Collections;
using UnityEngine;

namespace _Scripts.Enemy.EnemyCreator
{
    public class CreateEnemies : MonoBehaviour
    {
        private EnemyType _type;
        private EnemyCreator _creator;

        private void Start()
        {
            _type = EnemyType.Crab;

            StartCoroutine(Create());
        }

        private IEnumerator Create()
        {
            for (var i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(Random.Range(1, 3));
                SetEnemyCreator();
                var enemy = _creator.CreateEnemy();
            }
        }

        private void SetEnemyCreator()
        {
            switch (_type)
            {
                case EnemyType.None:
                    break;
                case EnemyType.Crab:
                {
                    var randomCrab = SetRandom();
                    if (randomCrab == 0)
                        _creator = new RedCrabCreator();
                    else
                        _creator = new StrangeCrabCreator();
                    break;
                }
            }
        }

        private static int SetRandom()
        {
            var randomCrab = Random.Range(0, 2);
            return randomCrab;
        }
    }
}