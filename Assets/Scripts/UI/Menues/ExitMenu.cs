using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Core;

    public class ExitMenu : UIElement
    {
        [SerializeField] private Button exitButton = null;

        public void OnExitButtonPressed()
        {
            App.Exit();
        }

        protected override void OnEnabled()
        {
            if (exitButton)
                exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        protected override void OnDisabled()
        {
            if (exitButton)
                exitButton.onClick.RemoveListener(OnExitButtonPressed);
        }
    }
}