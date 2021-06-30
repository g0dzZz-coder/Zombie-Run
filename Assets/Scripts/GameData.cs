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
        public MovementSettings movement;

        [Header("Input")]
        public FloatVariable controlSensitivity = null;

        public float MoveSpeed => movement.moveSpeed.value;
        public float TurnSpeed => movement.turnSpeed;
        public LevelGroup Levels => _levels;
    }
}