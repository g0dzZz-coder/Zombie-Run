using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Levels
{
    using Entities.Spawn;
    using Player;
    using Triggers;
    using Utils;

    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _start = null;
        [SerializeField] private EndLevelTrigger _endLevelTrigger = null;
        [SerializeField] private List<Spawner> _spawners = new List<Spawner>();

        public LevelData Data { get; private set; }

        public void Init(LevelData data)
        {
            Data = data;
            Restart();
        }

        public void Restart()
        {
            foreach (Spawner spawner in _spawners)
                spawner.Respawn();

            Player.Instance.SetPosition(_start.position);
        }

        public float GetRemainingDistance()
        {
            try
            {
                var endPosition = _endLevelTrigger.transform.position;
                var closestCharacterPosition = Player.Instance.Characters.GetClosest(endPosition).transform.position;
                return (endPosition - closestCharacterPosition).sqrMagnitude;
            }
            catch
            {
                return float.MaxValue;
            }
        }
    }
}