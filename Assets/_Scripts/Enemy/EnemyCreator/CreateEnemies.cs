using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Enemy.EnemyCreator
{
    public class CreateEnemies : MonoBehaviour
    {
        private EnemyType _type;
        private EnemySpecific _specific;
        private EnemyCreator _creator;

        private void Start()
        {
            _type = EnemyType.Crab;
            _specific = EnemySpecific.Default;
            StartCoroutine(Create());
        }

        private IEnumerator Create()
        {
            for (var i = 0; i < 3; i++)
            {
                _type = (EnemyType) i;
                yield return new WaitForSeconds(Random.Range(1, 3));
                SetEnemyCreator();
                _creator.Create(_type);
            }
        }

        private void SetEnemyCreator()
        {
            switch (_specific)
            {
                case EnemySpecific.None: break;
                case EnemySpecific.Default:
                {
                    _creator = new DefaultEnemyCreator();
                    break;
                }
                case EnemySpecific.Bug:
                    _creator = new BugEnemyCreator();
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}