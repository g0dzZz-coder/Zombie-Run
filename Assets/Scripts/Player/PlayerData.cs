using UnityEngine;

namespace ZombieRun.Player
{
    using Entities;

    [CreateAssetMenu(fileName = "Player", menuName = "Entities/Player", order = 51)]
    public class PlayerData : EntityData
    {
        public Player prefab = null;
        public CharacterData character = null;
    }
}