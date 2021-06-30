using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Misc;

    public class StartMenu : UIElement
    {
        [SerializeField] private GameEvent _gameStartingEvent = null;
        [SerializeField] private Button _button = null;

        private void Awake()
        {
            Show();
        }

        protected override void OnEnabled()
        {
            if (_button)
                _button.onClick.AddListener(OnStartButtonPressed);
        }

        protected override void OnDisabled()
        {
            if (_button)
                _button.onClick.RemoveListener(OnStartButtonPressed);
        }

        public void OnStartButtonPressed()
        {
            Hide();

            _gameStartingEvent?.Invoke();
        }
    }
}