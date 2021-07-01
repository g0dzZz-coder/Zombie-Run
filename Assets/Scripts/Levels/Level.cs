using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Levels
{
    using Entities.Spawn;
    using Player;

    public class Level : MonoBehaviour
    {
        [SerializeField] private LevelCheckpoints _checkpoints = default;
        [SerializeField] private List<Spawner> _spawners = new List<Spawner>();
        [SerializeField] private bool _rebuildOnStart = true;

        public LevelData Data { get; private set; }
        public LevelCheckpoints Checkpoints => _checkpoints;

        public void Init(LevelData data)
        {
            Data = data;
            Restart();
        }

        public void Restart()
        {
            Player.Instance.SetPosition(_checkpoints.start.position);

            if (_rebuildOnStart == false)
                return;

            foreach (Spawner spawner in _spawners)
                spawner.Respawn();
        }
    }
}