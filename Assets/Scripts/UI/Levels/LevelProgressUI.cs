using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Levels;

    public class LevelProgressUI : MonoBehaviour
    {
        [SerializeField] private Level _level = null;
        [SerializeField] private Slider _slider = null;

        private float _fullDistance;
        private float _lastDistance;

        private void Start()
        {
            UpdateProgressFill(0f);

            _fullDistance = GetDistance();
        }

        private void LateUpdate()
        {
            var distance = GetDistance();
            if (_level == null || distance == _lastDistance)
                return;

            _lastDistance = distance;
            var progressValue = Mathf.InverseLerp(_fullDistance, 0f, _lastDistance);

            UpdateProgressFill(progressValue);
        }

        private void UpdateProgressFill(float value)
        {
            _slider.value = value;
        }

        private float GetDistance()
        {
            return (_level.GetFinishPosition() - _level.GetClosestCharacter().transform.position).sqrMagnitude;
        }
    }
}