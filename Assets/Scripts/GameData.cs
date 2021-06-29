using System;
using UnityEngine;

namespace ZombieRun
{
    using Misc;

    [Serializable]
    public struct MovementSettings
    {
        public FloatVariable moveSpeed;
        public float turnSpeed;
    }

    [CreateAssetMenu(fileName = "Game Settings", menuName = "Settings/Game", order = 51)]
    public class GameData : ScriptableObject
    {
        public float stackingRadius = 3f;
        public FloatVariable controlSensitivity = null;

        [SerializeField] private MovementSettings _movement;

        public float MoveSpeed => _movement.moveSpeed.value;
        public float TurnSpeed => _movement.turnSpeed;
    }
}