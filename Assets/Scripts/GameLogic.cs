using UnityEngine;

namespace ZombieRun
{
    using Entities;
    using Cameras;
    using Levels;

    public class GameLogic : MonoBehaviour
    {
        [SerializeField] private CameraController _cameraController = null;
        [SerializeField] private Transform _root = null;
        [SerializeField] private LevelGroup _levelGroup = null;

        private Level _currentLevel;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            LoadNextLevel();

            _cameraController.SetTarget(_currentLevel.Player.transform);
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