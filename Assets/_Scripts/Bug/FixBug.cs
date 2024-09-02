using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace _Scripts.Bug
{
    public class FixBug : MonoBehaviour, IFix
    {
        public static event Action<float> OnFixingBug;
        public event Action OnFixedBug;

        [SerializeField] private float bugLifeTime = 20;

        private float BugLifeTime
        {
            get => bugLifeTime;
            set
            {
                bugLifeTime = value;
                if (bugLifeTime <= 0) FixedBug();
            }
        }

        private void Start()
        {
            BugLifeTime = 20;
        }

        public void Fix()
        {
            StartCoroutine(FixWithTime());
        }

        private IEnumerator FixWithTime()
        {
            if (gameObject == null) yield return null;
            if (BugLifeTime > 0)
            {
                FixingBug();
                yield return null;
            }
        }

        private void FixedBug()
        {
            OnFixedBug?.Invoke();
            Destroy(gameObject);
        }

        private void FixingBug()
        {
            BugLifeTime -= Time.deltaTime;
            OnFixingBug?.Invoke(BugLifeTime);
        }

        public class Factory : PlaceholderFactory<Vector3, Quaternion, Transform, FixBug>
        {
            private readonly DiContainer _container;
            private readonly GameObject _bugPrefab;

            public Factory(DiContainer container, GameObject bugPrefab)
            {
                _container = container;
                _bugPrefab = bugPrefab;
            }

            public override FixBug Create(Vector3 position, Quaternion rotation, Transform parent)
            {
                return _container.InstantiatePrefabForComponent<FixBug>(_bugPrefab, position, rotation, parent);
            }
        }
    }
}