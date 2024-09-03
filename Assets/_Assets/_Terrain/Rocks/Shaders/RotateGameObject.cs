using UnityEngine;

namespace _Assets.Rocks_and_Boulders_2.Shaders
{
    public class RotateGameObject : MonoBehaviour
    {
        public float rotSpeedX;
        public float rotSpeedY;
        public float rotSpeedZ;
        public bool local;

        private void FixedUpdate()
        {
            if (local)
#pragma warning disable 618
                transform.RotateAroundLocal(transform.up, Time.fixedDeltaTime * rotSpeedX);
#pragma warning restore 618
            else
                transform.Rotate(Time.fixedDeltaTime * new Vector3(rotSpeedX, rotSpeedY, rotSpeedZ), Space.World);
        }
    }
}