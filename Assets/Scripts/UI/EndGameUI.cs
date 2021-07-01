using TMPro;
using UnityEngine;

namespace ZombieRun.UI
{
    public class EndGameUI : UIElement
    {
        [SerializeField] private TMP_Text _text = null;

        [SerializeField] private string _winMessage = "You win";
        [SerializeField] private string _defeatMessage = "You loose";

        private void Awake()
        {
            Disable();

            GameLogic.Instance.GameEnded += OnGameEnded;
        }

        protected override void OnDisabled() { }

        protected override void OnEnabled() { }

        private void OnGameEnded(bool win)
        {
            if (win)
                _text.text = _winMessage;
            else
                _text.text = _defeatMessage;

            Show();
        }
    }
}