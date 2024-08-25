using System;
using System.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Bug
{
    public class FixBug : MonoBehaviour, IFix
    {
        public static event Action<float> FixingBug;
        public static event Action FixedBug;

        private float _bugLifeTime = 20;

        public async void Fix()
        {
            if (gameObject == null) return;

            if (_bugLifeTime > 0)
            {
                Debug.Log(_bugLifeTime);
                _bugLifeTime -= Time.deltaTime;
                FixingBug?.Invoke(_bugLifeTime);
                await Task.Yield();
            }

            if (_bugLifeTime <= 0)
            {
                FixedBug?.Invoke();
                Destroy(gameObject);
            }  
        }
    }
}