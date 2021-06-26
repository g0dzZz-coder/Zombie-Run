using UnityEngine;

namespace ZombieRun.Levels
{
    using Player;
    using Entities;
    using Utils;

    public class Level : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab = null;
        [SerializeField] private StartZone _startZone = null;
        [SerializeField] private FinishZone _finishZone = null;

        public LevelData Data { get; private set; }
        public Player Player { get; private set; }

        public void Init(LevelData data)
        {
            Data = data;

            Player = _startZone.CreatePlayer(_playerPrefab);
            _finishZone.Init();
        }

        public void Restart()
        {

        }

        public Vector3 GetFinishPosition()
        {
            return _finishZone.transform.position;
        }

        public Character GetClosestCharacter()
        {
            return Player.Characters.GetClosest(_finishZone.transform.position);
        }
    }
}