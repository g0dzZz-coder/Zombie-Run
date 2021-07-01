using UnityEngine;

namespace ZombieRun.UI
{
    using Misc;

    public class StartLevelUI : UIElement
    {
        [SerializeField] private GameEvent _gameStartingEvent = null;

        private void Awake()
        {
            Show();
        }

        public void OnStartButtonPressed()
        {
            Hide();

            _gameStartingEvent?.Invoke();
        }
    }
}