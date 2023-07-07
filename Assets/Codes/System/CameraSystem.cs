using QFramework;
using UnityEngine;

namespace PlatformShoot
{
    public interface ICameraSystem : ISystem
    {
        void SetTarget(Transform target);
        void Update();
    }

    public class CameraSystem : AbstractSystem, ICameraSystem
    {
        private Transform mTarget;

        protected override void OnInit()
        {
        }

        public void SetTarget(Transform target)
        {
            mTarget = target;
        }

        public void Update()
        {
           Camera.main.transform.localPosition =
               new Vector3(mTarget.localPosition.x, mTarget.localPosition.y, -10);
        }
    }
}