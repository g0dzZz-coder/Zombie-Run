using UnityEngine;

namespace ZombieRun.UI
{
    using Misc;

    public class BillboardUIElement : UIElement
    {
        protected Camera Camera { get; private set; }

        private void Awake()
        {
            Camera = CameraFollow.Instance.Camera;
            Disable();
        }

        private void LateUpdate()
        {
            RotateToCamera();
        }

        private void RotateToCamera()
        {
            if (Camera == null)
                return;

            Root.LookAt(transform.position + Camera.transform.rotation * Vector3.forward,
                Camera.transform.rotation * Vector3.up);
        }
    }
}