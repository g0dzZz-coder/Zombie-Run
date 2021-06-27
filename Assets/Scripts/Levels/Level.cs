using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Levels
{
    using Entities;
    using Entities.Spawn;
    using Player;
    using Utils;
    using Triggers;

    public class Level : MonoBehaviour
    {
        [SerializeField] private EndLevelTrigger _endLevelTrigger = null;
        [SerializeField] private List<Spawner> _spawners = new List<Spawner>();

        public LevelData Data { get; private set; }
        public Player Player { get; private set; }

        public void Init(LevelData data)
        {
            Data = data;

            foreach (Spawner spawner in _spawners)
                spawner.Respawn();

            Player = FindObjectOfType<Player>();
        }

        public void Restart()
        {

        }

        public Vector3 GetFinishPosition()
        {
            return _endLevelTrigger.transform.position;
        }

        public Character GetClosestCharacter()
        {
            return Player.Characters.GetClosest(_endLevelTrigger.transform.position);
        }
    }
}