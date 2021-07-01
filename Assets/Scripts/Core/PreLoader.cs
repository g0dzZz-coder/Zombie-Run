using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieRun.Core
{
    using Misc;

    /// <summary>
    /// First scene preloader.
    /// Needed to store singletons without using DontDestroyOnLoad().
    /// </summary>
    public class PreLoader : MonoBehaviour
    {
        public const string PreloadSceneName = "Preload";

        [Scene]
        [SerializeField] private string _nextSceneName = "Menu";

        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            // Comment out this line to disable the forced launch of the preload scene.
            SceneManager.LoadScene(PreloadSceneName);
        }

        private void Awake()
        {
            LoadScene(_nextSceneName);
        }

        private static void LoadScene(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || SceneManager.GetActiveScene().name == name)
                return;

            SceneChanger.Instance.FadeToScene(name);
        }
    }
}