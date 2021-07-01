using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Levels
{
    using Entities.Spawn;
    using Misc;
    using Player;
    using Utils;

    public class LevelLogic : MonoSingleton<LevelLogic>
    {
        [SerializeField] private LevelData _data = null;
        [SerializeField] private LevelCheckpoints _checkpoints = default;
        [SerializeField] private List<Spawner> _spawners = new List<Spawner>();

        [Header("Events")]
        [SerializeField] private GameEvent _levelStarted = null;
        [SerializeField] private GameEvent _levelEnded = null;

        public LevelCheckpoints Checkpoints => _checkpoints;
        public bool IsStarted { get; private set; }

        public event Action<bool> LevelEnded;

        public void StartLevel()
        {
            if (IsStarted)
                return;

            Player.Instance.SetPosition(_checkpoints.start.position);

            foreach (Spawner spawner in _spawners)
                spawner.Respawn();

            GameLogic.Instance.OnLevelStarted(_data);

            _levelStarted?.Invoke();
            IsStarted = true;
        }

        public void EndLevel(bool win)
        {
            if (IsStarted == false)
                return;

            IsStarted = false;
            GameLogic.Instance.OnLevelEnded(win);

            _levelEnded?.Invoke();
            LevelEnded?.Invoke(win);
        }
    }
}