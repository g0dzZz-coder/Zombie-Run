using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Core;
    using Levels;
    using Input = UnityEngine.Input;

    public class PauseMenu : UIElement
    {
        [SerializeField] private CanvasGroup _pauseButtonRoot = null;
        [SerializeField] private Button _resumeButton = null;

        private void Start()
        {
            Disable();
            _pauseButtonRoot.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
                TogglePause();
        }

        public void TogglePause()
        {
            if (LevelLogic.Instance.IsStarted == false)
                return;

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
            HidePauseButton();
        }

        private void OnUnpaused()
        {
            App.UnPause();

            Hide();
            ShowPauseButton();
        }

        public void ShowPauseButton()
        {
            _pauseButtonRoot.alpha = 1f;
            _pauseButtonRoot.gameObject.SetActive(true);

            LeanTween.alphaCanvas(_pauseButtonRoot, 1f, AnimationDuration);
        }

        public void HidePauseButton()
        {
            LeanTween.alphaCanvas(_pauseButtonRoot, 0f, AnimationDuration).setOnComplete(
                () => _pauseButtonRoot.gameObject.SetActive(false));
        }
    }
}