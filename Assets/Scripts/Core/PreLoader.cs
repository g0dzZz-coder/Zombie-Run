using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieRun.Core
{
    public class PreLoader : MonoBehaviour
    {
        [Scene]
        [SerializeField] private string nextSceneName = "Menu";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Init()
        {
            SceneManager.LoadScene("PreLoad");
        }

        private void Awake()
        {
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
        }
    }
}