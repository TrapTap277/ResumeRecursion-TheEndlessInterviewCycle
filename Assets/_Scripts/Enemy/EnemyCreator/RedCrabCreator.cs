using UnityEngine;

namespace _Scripts.Enemy.EnemyCreator
{
    public class RedCrabCreator : EnemyCreator
    {
        private const string CRAB_PATH = "Prefabs/Red_Crab";

        public override EnemyStateMachine CreateEnemy()
        {
            var newCrab = Resources.Load<GameObject>(CRAB_PATH);
            var crab = Object.Instantiate(newCrab);
            var crabComponent = crab.AddComponent<EnemyStateMachine>();
            return crabComponent;
        }
    }
}