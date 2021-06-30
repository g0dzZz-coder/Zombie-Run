using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Core;

    public class ExitMenu : UIElement
    {
        [SerializeField] private Button _exitButton = null;

        public void OnExitButtonPressed()
        {
            App.Exit();
        }

        protected override void OnEnabled()
        {
            if (_exitButton)
                _exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        protected override void OnDisabled()
        {
            if (_exitButton)
                _exitButton.onClick.RemoveListener(OnExitButtonPressed);
        }
    }
}