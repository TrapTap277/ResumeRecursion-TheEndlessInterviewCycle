using UnityEngine;

namespace _Scripts.Enemy.EnemyCreator
{
    public class StrangeCrabCreator : EnemyCreator
    {
        private const string CRAB_PATH = "Prefabs/Strange_Crab";
        
        public override Enemy CreateEnemy()
        {
            var newCrab = Resources.Load<GameObject>(CRAB_PATH);
            var crab = Object.Instantiate(newCrab);
            var crabDie = crab.gameObject.AddComponent<CrabDie>();
            var crabMove = crab.gameObject.AddComponent<CrabMove>();
            var crabAttack = crab.gameObject.AddComponent<CrabAttack>();
            var crabComponent = crab.AddComponent<StrangeCrab>();
            crabComponent.Construct(crabAttack, crabMove, crabDie);
            return crabComponent;
        }
    }
}