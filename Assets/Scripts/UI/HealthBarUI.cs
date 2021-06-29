using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    public class HealthBarUI : UIElement
    {
        [SerializeField] private Slider _slider = null;

        private void LateUpdate()
        {
            var camera = Camera.main;
            Root.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
        }

        public void Init(float currenthHealth, float maxHealth)
        {
            Root.GetComponent<Canvas>().worldCamera = Camera.main;
            _slider.maxValue = maxHealth;

            UpdateProgressFill(currenthHealth);
        }

        protected override void OnEnabled() { }

        protected override void OnDisabled() { }

        public void UpdateProgressFill(float value)
        {
            Debug.Log(value);
            _slider.value = value;
        }
    }
}