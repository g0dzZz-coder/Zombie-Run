using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    public class HealthBarUI : UIElement
    {
        [SerializeField] private Slider _slider = null;

        private Transform _camera;

        public void Init(float startHealth)
        {
            _camera = Camera.main.transform;
            Root.GetComponent<Canvas>().worldCamera = Camera.main;

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

            Root.LookAt(transform.position + _camera.rotation * Vector3.forward, _camera.rotation * Vector3.up);
        }
    }
}