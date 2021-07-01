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
        [Range(0f, 1f)]
        public float turnSpeed;
    }

    [CreateAssetMenu(fileName = "Game Settings", menuName = "Settings/Game", order = 51)]
    public class GameData : ScriptableObject
    {
        [SerializeField] private LevelGroup _levels;

        [Header("Gameplay")]
        [Range(1f, 5f)]
        public float stackingRadius = 3f;
        public MovementSettings movement;

        [Header("Input")]
        public FloatVariable controlSensitivity = null;

        public float MoveSpeed => movement.moveSpeed.value;
        public LevelGroup Levels => _levels;
    }
}