using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Scripts.Bug
{
    public class BugCounterUI : IInitializable, IDisposable
    {
        private readonly TextMeshProUGUI _bugCountText;

        public BugCounterUI(TextMeshProUGUI bugCountText)
        {
            _bugCountText = bugCountText;
        }

        private void ChangeUI(int count)
        {
            _bugCountText.text = count.ToString();
        }

        public void Initialize()
        {
            BugCounter.OnChangedBugCount += ChangeUI;
        }

        public void Dispose()
        {
            BugCounter.OnChangedBugCount -= ChangeUI;
        }
    }
}