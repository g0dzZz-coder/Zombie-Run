using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    public class MainMenu : MonoBehaviour
    {
        [Scene]
        [SerializeField] private string gameScene = string.Empty;
        [SerializeField] private Button startButton = null;

        private void OnEnable()
        {
            if (startButton)
                startButton.onClick.AddListener(OnStartButtonPressed);
        }

        private void OnDisable()
        {
            if (startButton)
                startButton.onClick.RemoveListener(OnStartButtonPressed);
        }

        public void OnStartButtonPressed()
        {
            SceneChanger.Instance.FadeToScene(gameScene);
        }
    }
}