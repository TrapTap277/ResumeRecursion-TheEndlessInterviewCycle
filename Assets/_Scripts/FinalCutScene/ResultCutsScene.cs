using System;
using _Scripts.Bug;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.FinalCutScene
{
    public abstract class ResultCutsScene : IInitializable, IDisposable
    {
        public abstract void PlayCutScene();

        public void Initialize()
        {
            Debug.Log("initialize");
            BugCounter.OnFixedAllBugs += PlayCutScene;
        }

        public void Dispose()
        {
            BugCounter.OnFixedAllBugs -= PlayCutScene;
        }
    }

    public class GoodCutScene : ResultCutsScene
    {
        public override void PlayCutScene()
        {
            Debug.Log("Playing good cut scene");
        }
    }

    public class BadCutScene : ResultCutsScene
    {
        public override void PlayCutScene()
        {
            Debug.Log("Playing ad Bad scene");
        }
    }

    public class NeutralCutScene : ResultCutsScene
    {
        public override void PlayCutScene()
        {
            Debug.Log("Playing ad Neutral scene");
        }
    }
}