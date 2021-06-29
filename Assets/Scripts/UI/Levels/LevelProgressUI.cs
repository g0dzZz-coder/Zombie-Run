using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Levels;

    public class LevelProgressUI : UIElement
    {
        [SerializeField] private Slider _slider = null;

        private float _fullDistance;
        private float _lastDistance;

        private Level _level = null;

        private void Awake()
        {
            Hide();
        }

        private void LateUpdate()
        {
            if (_level == null)
                return;

            var distance = _level.GetRemainingDistance();
            if (distance == _lastDistance)
                return;

            _lastDistance = distance;
            var progressValue = Mathf.InverseLerp(_fullDistance, 0f, _lastDistance);

            UpdateProgressFill(progressValue);
        }

        protected override void OnEnabled()
        {
            _level = GameLogic.Instance.CurrentLevel;
            _fullDistance = _level.GetRemainingDistance();

            UpdateProgressFill(0f);
        }

        protected override void OnDisabled() { }

        private void UpdateProgressFill(float value)
        {
            _slider.value = value;
        }
    }
}