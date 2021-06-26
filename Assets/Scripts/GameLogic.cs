using UnityEngine;

namespace ZombieRun
{
    using Cameras;
    using Levels;

    public class GameLogic : MonoBehaviour
    {
        [SerializeField] private Transform _root = null;
        [SerializeField] private CameraFollow _camera = null;
        [SerializeField] private LevelGroup _levelGroup = null;

        [Header("Events")]
        [SerializeField] private GameEvent _onGameStarted = null;

        private Level _currentLevel;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            LoadNextLevel();

            _camera.SetTarget(_currentLevel.Player.GetClosestCharacter());

            _onGameStarted?.Raise();
        }

        private void LoadNextLevel()
        {
            var nextLevel = _levelGroup.GetNextLevel();
            LoadLevel(nextLevel);
        }

        private void LoadLevel(LevelData data)
        {
            for (var i = 0; i < _root.childCount; i++)
                Destroy(_root.GetChild(0).gameObject);

            _currentLevel = Instantiate(data.prefab, _root.transform);
            _currentLevel.Init(data);
        }
    }
}