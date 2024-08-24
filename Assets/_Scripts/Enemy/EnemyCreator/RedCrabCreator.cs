using UnityEngine;

namespace _Scripts.Enemy.EnemyCreator
{
    public class RedCrabCreator : EnemyCreator
    {
        private const string CRAB_PATH = "Prefabs/Red_Crab";
        
        public override Enemy CreateEnemy()
        {
            var newCrab = Resources.Load<GameObject>(CRAB_PATH);
            var crab = Object.Instantiate(newCrab);
            var crabDie = crab.gameObject.AddComponent<CrabDie>();
            var crabMove = crab.gameObject.AddComponent<CrabMove>();
            var crabAttack = crab.gameObject.AddComponent<CrabAttack>();
            var crabComponent = crab.AddComponent<RedCrab>();
            crabComponent.Construct(crabAttack, crabMove, crabDie);
            return crabComponent;
        }
    }
}