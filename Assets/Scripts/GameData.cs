using System;
using UnityEngine;
using ZombieRun.Input;

namespace ZombieRun
{
    using Misc;

    [Serializable]
    public class MovementSettings
    {
        public float moveSpeed;
        public float turnSpeed;

        public IInputProvider InputProvider { get; set; }

        public MovementSettings(float moveSpeed, float turnSpeed)
        {
            this.moveSpeed = moveSpeed;
            this.turnSpeed = turnSpeed;
        }
    }

    [CreateAssetMenu(fileName = "Game Settings", menuName = "Settings/Game", order = 51)]
    public class GameData : ScriptableObject
    {
        public float stackingRadius = 3f;
        public FloatVariable controlSensitivity = null;

        public MovementSettings movement = new MovementSettings(3f, 0.1f);
    }
}