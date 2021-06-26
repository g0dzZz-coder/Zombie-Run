using UnityEngine;

namespace ZombieRun.Levels
{
    using Player;

    public class Level : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab = null;
        [SerializeField] private Transform _startZone = null;
        [SerializeField] private BoxCollider _finishZone = null;

        public LevelData Data { get; private set; }
        public Player Player { get; private set; }

        public void Init(LevelData data)
        {
            Data = data;
            Player = CreatePlayer();
        }

        public Vector3 GetPlayerPosition()
        {
            return Player ? Player.transform.position : Vector3.zero;
        }

        public Vector3 GetFinishPosition()
        {
            return _finishZone.transform.position;
        }

        private Player CreatePlayer()
        {
            var player = Instantiate(_playerPrefab, _startZone);
            player.transform.SetParent(transform);
            player.transform.LookAt(_finishZone.transform);

            player.Init();

            return player;
        }
    }
}