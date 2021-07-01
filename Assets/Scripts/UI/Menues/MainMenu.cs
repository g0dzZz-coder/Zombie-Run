using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Levels;
    using Core;

    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private LevelGroup _levels = null;
        [SerializeField] private Button _startButton = null;

        private void OnEnable()
        {
            if (_startButton)
                _startButton.onClick.AddListener(OnStartButtonPressed);
        }

        private void OnDisable()
        {
            if (_startButton)
                _startButton.onClick.RemoveListener(OnStartButtonPressed);
        }

        public void OnStartButtonPressed()
        {
            var nextLevel = _levels.GetNextLevel().Scene;
            SceneChanger.Instance.FadeToScene(nextLevel);
        }
    }
}