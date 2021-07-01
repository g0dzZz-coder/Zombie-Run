using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieRun.Core
{
    using Utils;

    public class SceneChanger : MonoSingleton<SceneChanger>
    {
        [SerializeField] private CanvasGroup _canvasGroup = null;
        [Range(0f, 2f)]
        [SerializeField] private float _duration = 0.5f;

        private string _sceneToLoad = string.Empty;
        private string _lastScene = string.Empty;

        private void OnEnable()
        {
            PlayFadeInAnimation();
        }

        public void FadeToScene(string newScene, bool ignoreTheSame = true)
        {
            if (string.IsNullOrWhiteSpace(newScene))
                return;

            if (ignoreTheSame && newScene == SceneManager.GetActiveScene().name)
                return;

            _lastScene = SceneManager.GetActiveScene().name;
            _sceneToLoad = newScene;

            PlayFadeOutAnimation();
        }

        public void BackToPreviosScene()
        {
            _sceneToLoad = _lastScene;
            PlayFadeOutAnimation();
        }

        public void OnFadeComplete()
        {
            SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive).completed += operation => OnSceneLoaded();
        }

        private void PlayFadeInAnimation()
        {
            if (_canvasGroup == null)
                return;

            _canvasGroup.alpha = 1f;
            LeanTween.alphaCanvas(_canvasGroup, 0f, _duration);
        }

        private void PlayFadeOutAnimation()
        {
            if (_sceneToLoad == _lastScene)
                SceneManager.UnloadSceneAsync(_lastScene);

            if (_canvasGroup == null)
                return;

            LeanTween.alphaCanvas(_canvasGroup, 1f, _duration).setOnComplete(OnFadeComplete);
        }

        private void OnSceneLoaded()
        {
            if (_lastScene != PreLoader.PreloadSceneName && _lastScene != _sceneToLoad)
                SceneManager.UnloadSceneAsync(_lastScene);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneToLoad));
            _lastScene = _sceneToLoad;

            PlayFadeInAnimation();
        }

        private void OnValidate()
        {
            if (_canvasGroup == null)
                Debug.LogError($"[{nameof(SceneChanger)}] {nameof(CanvasGroup)} is empty!");
        }
    }
}
