using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieRun.Utils
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        protected static T instance;
        protected int instancesInScene;

        public static T Instance
        {
            get
            {
                if (instance != null)
                    return instance;

                return FindObjectOfType<T>();
            }
        }

        private void Awake()
        {
            OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        protected virtual void OnDestroy()
        {
            var numComponents = GetComponentsInChildren<Component>().Length;

            if (transform.childCount == 0 && numComponents <= 2)
                Destroy(gameObject);

            instancesInScene--;

            SceneManager.sceneLoaded -= OnSceneLoaded;

            if (Instance == this)
                instance = null;
        }

        protected virtual void OnAwake()
        {
            instancesInScene++;

            if (Init(Instance))
                instance = (T)this;
        }

        protected virtual void OnStart()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (instancesInScene < 2)
            {
                DisposeInternal();
            }
            else
            {
                if (Instance != this)
                    DisposeInternal();
            }
        }

        protected virtual bool Init(T instance)
        {
            if (instance != null && instance != this)
            {
                DisposeInternal();
                return false;
            }

            return true;
        }

        protected virtual void DisposeInternal()
        {
            Destroy(this);
        }
    }
}
