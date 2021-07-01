using UnityEngine;
using System;

namespace ZombieRun
{
    using Levels;
    using Misc;
    using Utils;

    public class GameLogic : MonoSingleton<GameLogic>
    {
        [SerializeField] private Transform _root = null;
        [SerializeField] private GameData _data = null;

        [Header("Events")]
        [SerializeField] private GameEvent _onGameStarted = null;
        [SerializeField] private GameEvent _onGameEnded = null;

        public GameData Data => _data;
        public bool IsStarted { get; private set; }
        public Level CurrentLevel { get; private set; }

        public event Action<bool> GameEnded;

        private bool _isLastLevelPassed = true;

        public void StartGame()
        {
            if (IsStarted)
                return;

            Player.Player.Instance.RemoveAllCharacters();

            CurrentLevel = GetNextLevel();
            CurrentLevel.Restart();

            _data.Levels.SetLastLevelPlayed(CurrentLevel.Data);

            _onGameStarted?.Invoke();
            IsStarted = true;
        }

        public void EndGame(bool win)
        {
            if (IsStarted == false)
                return;

            IsStarted = false;
            _isLastLevelPassed = win;

            _onGameEnded?.Invoke();
            GameEnded?.Invoke(win);
        }

        private Level GetNextLevel()
        {
            if (_isLastLevelPassed == false)
                return CurrentLevel;

            var nextLevelData = _data.Levels.GetNextLevel();
            if (CurrentLevel && nextLevelData == CurrentLevel.Data)
                return CurrentLevel;

            var nextLevel = LoadLevel(nextLevelData);

            return nextLevel;
        }

        private Level LoadLevel(LevelData data)
        {
            DestroyAllLevels();

            if (data == null)
                throw new ArgumentNullException("LevelData is null");

            var level = Instantiate(data.prefab, _root.transform);
            level.Init(data);

            return level;
        }

        private void DestroyAllLevels()
        {
            for (var i = 0; i < _root.childCount; i++)
                Destroy(_root.GetChild(i).gameObject);
        }
    }
}