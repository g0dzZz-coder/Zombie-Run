using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    public class MainMenu : MonoBehaviour
    {
        [Scene]
        [SerializeField] private string _gameScene = "Gameplay";
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
            SceneChanger.Instance.FadeToScene(_gameScene);
        }
    }
}