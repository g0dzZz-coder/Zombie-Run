using UnityEngine;

namespace ZombieRun
{
    using Levels;
    using Misc;
    using Utils;

    public class GameLogic : MonoSingleton<GameLogic>
    {
        [SerializeField] private Transform _root = null;
        [SerializeField] private LevelGroup _levelGroup = null;

        [Header("Events")]
        [SerializeField] private GameEvent _onGameStarted = null;
        [SerializeField] private GameEvent _onGameEnded = null;

        public bool IsStarted { get; private set; }
        public Level CurrentLevel { get; private set; }

        public void StartGame()
        {
            LoadNextLevel();
            OnGameStarted();
        }

        public void RestartGame()
        {
            CurrentLevel.Restart();
            OnGameStarted();
        }

        public void EndGame(bool win)
        {
            IsStarted = false;
            _onGameEnded?.Invoke();
        }

        private void LoadNextLevel()
        {
            var nextLevel = _levelGroup.GetNextLevel();
            LoadLevel(nextLevel);
        }

        private void LoadLevel(LevelData data)
        {
            for (var i = 0; i < _root.childCount; i++)
                Destroy(_root.GetChild(i).gameObject);

            CurrentLevel = Instantiate(data.prefab, _root.transform);
            CurrentLevel.Init(data);
        }

        private void OnGameStarted()
        {
            IsStarted = true;
            _onGameStarted?.Invoke();
        }
    }
}