using UnityEngine;

namespace ZombieRun
{
    using Levels;
    using Misc;
    using Utils;

    public class GameLogic : MonoSingleton<GameLogic>
    {
        [SerializeField] private Transform _root = null;
        [SerializeField] private GameData _data;

        [Header("Events")]
        [SerializeField] private GameEvent _onGameStarted = null;
        [SerializeField] private GameEvent _onGameEnded = null;

        public GameData Data => _data;
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
            var nextLevel = _data.Levels.GetNextLevel();
            LoadLevel(nextLevel);
        }

        private void LoadLevel(LevelData data)
        {
            //if (CurrentLevel)
            //    Destroy(CurrentLevel.gameObject);

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