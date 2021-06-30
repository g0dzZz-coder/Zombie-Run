using System;
using UnityEngine;

namespace ZombieRun
{
    using Misc;
    using Levels;

    [Serializable]
    public struct MovementSettings
    {
        public FloatVariable moveSpeed;
        public float turnSpeed;
    }

    [CreateAssetMenu(fileName = "Game Settings", menuName = "Settings/Game", order = 51)]
    public class GameData : ScriptableObject
    {
        [SerializeField] private LevelGroup _levels;

        [Header("Gameplay")]
        public float stackingRadius = 3f;
        [SerializeField] private MovementSettings _movement;

        [Header("Input")]
        public FloatVariable controlSensitivity = null;

        public float MoveSpeed => _movement.moveSpeed.value;
        public float TurnSpeed => _movement.turnSpeed;
        public LevelGroup Levels => _levels;
    }
}