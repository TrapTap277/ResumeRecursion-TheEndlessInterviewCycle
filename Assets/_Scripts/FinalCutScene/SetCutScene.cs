using System;

namespace _Scripts.FinalCutScene
{
    public class SetCutScene
    {
        public static void Set(CutSceneType type)
        {
            ResultCutsScene resultCutsScene = null;

            switch (type)
            {
                case CutSceneType.None:
                    break;
                case CutSceneType.Neutral:
                    resultCutsScene = new NeutralCutScene();
                    break;
                case CutSceneType.Good:
                    resultCutsScene = new GoodCutScene();
                    break;
                case CutSceneType.Bad:
                    resultCutsScene = new BadCutScene();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            if (resultCutsScene != null) resultCutsScene.PlayCutScene();
        }
    }
}