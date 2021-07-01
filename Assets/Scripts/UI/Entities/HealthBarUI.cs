using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI.Entities
{
    public class HealthBarUI : BillboardUIElement
    {
        [SerializeField] private Slider _slider = null;

        public void Init(float startHealth)
        {
            Root.GetComponent<Canvas>().worldCamera = Camera;

            _slider.maxValue = startHealth;
            UpdateProgressFill(startHealth);
        }

        public void UpdateProgressFill(float value)
        {
            _slider.value = value;
        }

        protected override void OnEnabled() { }

        protected override void OnDisabled() { }
    }
}