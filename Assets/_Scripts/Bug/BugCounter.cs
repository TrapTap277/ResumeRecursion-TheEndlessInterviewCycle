using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.FinalCutScene;
using UnityEngine;
using Zenject;

namespace _Scripts.Bug
{
    public class BugCounter : IInitializable, IDisposable
    {
        public static event Action<int> OnChangedBugCount;
        public static event Action OnFixedAllBugs;

        private readonly List<FixBug> _activeBugs = new List<FixBug>();
        private readonly BugCreator _bugCreator;

        private static int BugCount
        {
            get => _bugCount;
            set
            {
                _bugCount = value;
                OnChangedBugCount?.Invoke(value);
                if (_bugCount <= 0)
                {
                    SetCutScene.Set(CutSceneType.Good);
                    // OnFixedAllBugs?.Invoke();
                }
            }
        }

        private static int _bugCount;

        public BugCounter(int initialBugCount, BugCreator bugCreator)
        {
            BugCount = initialBugCount;
            _bugCreator = bugCreator;
        }

        private void RemoveBug(FixBug bug)
        {
            _activeBugs.Remove(bug);
            BugCount--;
        }

        public void Initialize()
        {
            _bugCreator.OnBugCreated += OnBugCreated;


            for (int i = 0; i < BugCount; i++)
            {
                _bugCreator.Create();
            }

            _bugCreator.StartCoroutine(ChangeBugCountWithFrame());
        }

        private IEnumerator ChangeBugCountWithFrame()
        {
            yield return new WaitForEndOfFrame();
            OnChangedBugCount?.Invoke(BugCount);
        }

        private void OnBugCreated(FixBug bug)
        {
            _activeBugs.Add(bug);
            bug.OnFixedBug += () => RemoveBug(bug);
        }

        public void Dispose()
        {
            _bugCreator.OnBugCreated -= OnBugCreated;
            foreach (var bug in _activeBugs)
            {
                bug.OnFixedBug -= () => RemoveBug(bug);
            }

            _activeBugs.Clear();
        }
    }
}