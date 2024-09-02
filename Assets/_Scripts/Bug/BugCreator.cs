using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Scripts.Bug
{
    public class BugCreator : MonoBehaviour
    {
        public event Action<FixBug> OnBugCreated;

        [SerializeField] public List<Transform> spawnPos;
        [SerializeField] public GameObject bugPrefab;

        private DiContainer _container;

        [Inject]
        public void Construct(DiContainer container)
        {
            _container = container;
        }

        public FixBug Create()
        {
            var randomPos = spawnPos[UnityEngine.Random.Range(0, spawnPos.Count)];
            var bugObject = _container.InstantiatePrefab(bugPrefab, randomPos.position, Quaternion.identity, null);
            var fixBug = bugObject.GetComponent<FixBug>();
            
            if (fixBug != null)
            {
                OnBugCreated?.Invoke(fixBug);
            }
            else
            {
                Debug.LogError("FixBug component not found on instantiated prefab!");
            }

            return fixBug;
        }
    }
}