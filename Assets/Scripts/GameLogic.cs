using System;
using UnityEngine;

namespace ZombieRun
{
    using Core;
    using Levels;
    using Utils;

    public class GameLogic : MonoSingleton<GameLogic>
    {
        [SerializeField] private GameData _data = null;

        public GameData Data => _data;

        private LevelData _currentLevel = null;
        private bool _isLastLevelPassed = true;

        public void OnLevelStarted(LevelData level)
        {
            _currentLevel = level;
            _data.Levels.SetLastLevelPlayed(_currentLevel);
        }

        public void OnLevelEnded(bool win)
        {
            _isLastLevelPassed = win;
        }

        public void LoadNextLevel()
        {
            var nextLevelData = GetNextLevel();
            LoadLevel(nextLevelData);
        }

        private void LoadLevel(LevelData data)
        {
            if (data == null)
                throw new ArgumentNullException("LevelData is null");

            SceneChanger.Instance.FadeToScene(data.Scene, false);
        }

        private LevelData GetNextLevel()
        {
            if (_isLastLevelPassed == false)
                return _currentLevel;

            var nextLevelData = _data.Levels.GetNextLevel();
            if (nextLevelData == _data)
                return _currentLevel;

            return nextLevelData;
        }
    }
}