using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Levels;
    using Player;
    using Utils;

    public class LevelProgressUI : UIElement
    {
        public enum Method
        {
            Root,
            ClosestCharacter
        }

        [SerializeField] private Slider _slider = null;
        [SerializeField] private Method _methodOfCalculation = Method.ClosestCharacter;

        private float _fullDistance;
        private float _lastDistance;

        private LevelLogic _level = null;

        private void Awake()
        {
            Disable();
        }

        private void Update()
        {
            if (_level == null || enabled == false)
                return;

            var distance = GetRemainingDistance();
            if (distance == _lastDistance)
                return;

            _lastDistance = distance;
            var progressValue = Mathf.InverseLerp(_fullDistance, 0f, _lastDistance);

            UpdateProgressFill(progressValue);
        }


        protected override void OnEnabled()
        {
            _level = LevelLogic.Instance;
            _fullDistance = GetRemainingDistance();
        }

        protected override void OnDisabled()
        {
            UpdateProgressFill(0f);
        }

        private void UpdateProgressFill(float value)
        {
            _slider.value = value;
        }

        private float GetRemainingDistance()
        {
            try
            {
                var endPosition = _level.Checkpoints.end.transform.position;
                var currentPosition = _methodOfCalculation == Method.Root
                    ? Player.Instance.Root.position
                    : Player.Instance.Characters.GetClosest(endPosition).transform.position;

                return (endPosition - currentPosition).sqrMagnitude;
            }
            catch
            {
                return float.MaxValue;
            }
        }
    }
}