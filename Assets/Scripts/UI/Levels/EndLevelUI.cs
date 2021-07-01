using TMPro;
using UnityEngine;

namespace ZombieRun.UI
{
    using Levels;

    public class EndLevelUI : UIElement
    {
        [SerializeField] private TMP_Text _text = null;

        [SerializeField] private string _winMessage = "You win";
        [SerializeField] private string _defeatMessage = "You loose";

        private void Awake()
        {
            Disable();

            LevelLogic.Instance.LevelEnded += OnLevelEnded;
        }

        private void OnLevelEnded(bool win)
        {
            if (win)
                _text.text = _winMessage;
            else
                _text.text = _defeatMessage;

            Show();
        }

        public void OnEndButtonPressed()
        {
            Hide();

            GameLogic.Instance.LoadNextLevel();
        }
    }
}