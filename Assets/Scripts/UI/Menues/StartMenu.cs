using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun.UI
{
    using Misc;

    public class StartMenu : UIElement
    {
        [SerializeField] private GameEvent onClicked = null;
        [SerializeField] private Button _button = null;

        private void Awake()
        {
            Show();
        }

        protected override void OnEnabled()
        {
            _button.onClick.AddListener(onClicked.Invoke);
        }

        protected override void OnDisabled()
        {
            _button.onClick.RemoveListener(onClicked.Invoke);
        }
    }
}