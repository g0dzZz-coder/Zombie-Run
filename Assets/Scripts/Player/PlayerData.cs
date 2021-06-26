using UnityEngine;
using System;

[Serializable]
public struct MovementSettings
{
    public float moveSpeed;
    public float turnSpeed;

    public MovementSettings(float moveSpeed, float turnSpeed)
    {
        this.moveSpeed = moveSpeed;
        this.turnSpeed = turnSpeed;
    }
}

namespace ZombieRun.Player
{
    using Entities;

    [CreateAssetMenu(fileName = "Player", menuName = "Settings/Player", order = 51)]
    public class PlayerData : ScriptableObject
    {
        public Player prefab = null;
        public CharacterData character = null;

        public MovementSettings movement = new MovementSettings(3f, 0.1f);
    }
}