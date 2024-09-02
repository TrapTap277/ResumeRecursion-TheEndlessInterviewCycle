using _Scripts.Enemy.SO;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemySo defaultEnemySo;

        public override void InstallBindings()
        {
        }
    }
}