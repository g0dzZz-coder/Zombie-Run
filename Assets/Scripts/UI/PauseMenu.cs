using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Core;

    public class PauseMenu : PopupMenu
    {
        [SerializeField] private Button resumeButton = null;

        private void Start()
        {
            Disable();
        }

        private void OnEnable()
        {
            if (resumeButton)
                resumeButton.onClick.AddListener(OnUnpaused);
        }

        private void OnDisable()
        {
            if (resumeButton)
                resumeButton.onClick.RemoveListener(OnUnpaused);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
                TogglePause();
        }

        public void TogglePause()
        {
            if (Game.IsPaused)
                OnUnpaused();
            else
                OnPaused();
        }

        private void OnPaused()
        {
            Game.Pause();
            Show();
        }

        private void OnUnpaused()
        {
            Game.UnPause();
            Hide();
        }
    }
}