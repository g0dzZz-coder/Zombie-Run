using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieRun.Core
{
    using UI;

    public class PreLoader : MonoBehaviour
    {
        public const string PreloadSceneName = "Preload";

        [Scene]
        [SerializeField] private string nextSceneName = "Menu";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Init()
        {
            SceneManager.LoadScene(PreloadSceneName);
            //LoadScene(PreloadSceneName);
        }

        private void Awake()
        {
            LoadScene(nextSceneName, LoadSceneMode.Additive);
        }

        private static void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single)
        {
            if (string.IsNullOrWhiteSpace(name) || SceneManager.GetActiveScene().name == name)
                return;

            SceneChanger.Instance.FadeToScene(name);
            //SceneManager.LoadScene(name, mode);
        }
    }
}