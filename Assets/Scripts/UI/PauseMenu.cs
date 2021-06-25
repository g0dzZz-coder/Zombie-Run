using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Core;

    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button resumeButton = null;

        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
                TogglePause();
        }

        public void TogglePause()
        {
            if (Game.IsPaused)
                OnPaused();
            else
                OnUnpaused();
        }

        private void OnPaused()
        {

        }

        private void OnUnpaused()
        {

        }
    }
}