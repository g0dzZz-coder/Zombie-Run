using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Core;
    using Input = UnityEngine.Input;

    public class PauseMenu : UIElement
    {
        [SerializeField] private Button _resumeButton = null;

        private void Start()
        {
            Disable();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
                TogglePause();
        }

        public void TogglePause()
        {
            if (App.IsPaused)
                OnUnpaused();
            else
                OnPaused();
        }

        protected override void OnEnabled()
        {
            App.Pause();

            if (_resumeButton)
                _resumeButton.onClick.AddListener(OnUnpaused);
        }

        protected override void OnDisabled()
        {
            if (_resumeButton)
                _resumeButton.onClick.RemoveListener(OnUnpaused);
        }

        private void OnPaused()
        {
            Show();
        }

        private void OnUnpaused()
        {
            App.UnPause();
            Hide();
        }
    }
}