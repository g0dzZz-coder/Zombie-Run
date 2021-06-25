using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ZombieRun.UI
{
    using Levels;

    public class LevelProgressUI : MonoBehaviour
    {
        [SerializeField] private Level _level = null;

        [Header("UI")]
        [SerializeField] private Image _image = null;
        [SerializeField] private TMP_Text _currentLevelText = null;
        [SerializeField] private TMP_Text _nextLevelText = null;

        private float _fullDistance;

        private void Start()
        {
            _image.type = Image.Type.Filled;
            UpdateProgressFill(0f);

            _fullDistance = GetDistance();
        }

        private void Update()
        {
            if (_level == null || _level.GetPlayerPosition().x > _level.GetFinishPosition().x)
                return;

            var newDistance = GetDistance();
            var progressValue = Mathf.InverseLerp(_fullDistance, 0f, newDistance);

            UpdateProgressFill(progressValue);
        }

        private void UpdateProgressFill(float value)
        {
            _image.fillAmount = value;
        }

        private float GetDistance()
        {
            //return Vector3.Distance(_level.GetPlayerPosition(), _level.GetFinishPosition());
            return (_level.GetFinishPosition() - _level.GetPlayerPosition()).sqrMagnitude;
        }
    }
}