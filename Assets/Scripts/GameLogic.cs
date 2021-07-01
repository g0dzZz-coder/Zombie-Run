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

        public void StartGame()
        {
            PrepareLevel();
            _data.Levels.SetLastLevelPlayed(CurrentLevel.Data);

            IsStarted = true;
            _onGameStarted?.Invoke();
        }

        public void EndGame(bool win)
        {
            IsStarted = false;

            _onGameEnded?.Invoke();
            GameEnded?.Invoke(win);
        }

        private void LoadNextLevel()
        {
            var nextLevel = _data.Levels.GetNextLevel();
            LoadLevel(nextLevel);
        }

        private void LoadLevel(LevelData data)
        {
            DestroyAllLevels();

            if (data == null)
                throw new ArgumentNullException("LevelData is null");

            CurrentLevel = Instantiate(data.prefab, _root.transform);
            CurrentLevel.Init(data);
        }

        private void PrepareLevel()
        {
            if (CurrentLevel == null)
            {
                LoadNextLevel();
                return;
            }

            Player.Player.Instance.RemoveAllCharacters();
            CurrentLevel.Restart();
        }

        private void DestroyAllLevels()
        {
            for (var i = 0; i < _root.childCount; i++)
                Destroy(_root.GetChild(i).gameObject);
        }

        private void DestroyCurrentLevel()
        {
            if (CurrentLevel)
                Destroy(CurrentLevel.gameObject);
        }
    }
}