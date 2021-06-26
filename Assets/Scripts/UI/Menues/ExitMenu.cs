using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Core;

    public class ExitMenu : MonoBehaviour
    {
        [SerializeField] private Button exitButton = null;

        private void OnEnable()
        {
            if (exitButton)
                exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        private void OnDisable()
        {
            if (exitButton)
                exitButton.onClick.RemoveListener(OnExitButtonPressed);
        }

        public void OnExitButtonPressed()
        {
            App.Exit();
        }
    }
}