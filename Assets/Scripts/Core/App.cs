using System;
using UnityEditor;
using UnityEngine;

namespace ZombieRun.Core
{
    public static class App
    {
        public static bool IsPaused { get; private set; }

        public static event Action Paused;
        public static event Action UnPaused;

        public static void Pause()
        {
            Time.timeScale = 0;
            IsPaused = true;

            Paused?.Invoke();
        }

        public static void UnPause()
        {
            Time.timeScale = 1;
            IsPaused = false;

            UnPaused?.Invoke();
        }

        public static void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif
            Application.Quit();
        }
    }
}