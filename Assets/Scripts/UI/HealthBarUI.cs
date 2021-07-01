using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Misc;

    public class HealthBarUI : UIElement
    {
        [SerializeField] private Slider _slider = null;

        private Camera _camera;

        public void Init(float startHealth)
        {
            _camera = CameraFollow.Instance.Camera;
            Root.GetComponent<Canvas>().worldCamera = _camera;

            _slider.maxValue = startHealth;
            UpdateProgressFill(startHealth);
        }

        private void LateUpdate()
        {
            RotateToCamera();
        }

        public void UpdateProgressFill(float value)
        {
            _slider.value = value;
        }

        protected override void OnEnabled() { }

        protected override void OnDisabled() { }

        private void RotateToCamera()
        {
            if (_camera == null)
                return;

            Root.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, 
                _camera.transform.rotation * Vector3.up);
        }
    }
}