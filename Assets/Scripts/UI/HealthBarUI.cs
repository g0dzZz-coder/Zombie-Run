using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Entities;

    public class HealthBarUI : UIElement
    {
        [SerializeField] private Health _health = null;
        [SerializeField] private Slider _slider = null;

        private Transform _camera;

        private void Start()
        {
            _camera = Camera.main.transform;
            Root.GetComponent<Canvas>().worldCamera = Camera.main;
            _slider.maxValue = _health.MaxHealth;

            UpdateProgressFill(_health.CurrentHealth);
        }

        private void LateUpdate()
        {
            RotateToCamera();
        }

        private void OnEnable()
        {
            _health.HealthChanged += value => UpdateProgressFill(value);
        }

        private void OnDisable()
        {
            _health.HealthChanged -= value => UpdateProgressFill(value);
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