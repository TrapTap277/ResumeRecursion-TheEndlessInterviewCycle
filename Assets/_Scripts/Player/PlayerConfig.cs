using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player
{
    public class PlayerConfig : MonoBehaviour
    {
        public JumpBehaviour jumpBehaviour;
        public ShiftingBehaviour shiftingBehaviour;
        public WalkBehaviour walkBehaviour;
        public RunBehaviour runBehaviour;
        public CameraLook cameraLook;
        public AttackBehaviour attackBehaviour;
        [HideInInspector] public string shiftingID = "Shifting";
        [HideInInspector] public string moveID = "Move";
        [HideInInspector] public string runID = "Run";
        [HideInInspector] public string cameraID = "Camera";
    }
}