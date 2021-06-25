using UnityEngine;

namespace ZombieRun.Levels
{
    using Entities;

    public class Level : MonoBehaviour
    {
        [SerializeField] private PlayerGroup _playerPrefab = null;
        [SerializeField] private Transform startZone = null;
        [SerializeField] private Transform finishZone = null;

        public LevelData Data { get; private set; }
        public PlayerGroup Player { get;private set; }

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
            return finishZone.position;
        }

        private PlayerGroup CreatePlayer()
        {
            var player = Instantiate(_playerPrefab, startZone);
            player.transform.SetParent(transform);
            player.transform.LookAt(finishZone);

            player.Init();

            return player;
        }
    }
}