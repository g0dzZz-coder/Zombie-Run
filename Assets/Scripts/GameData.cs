using UnityEngine;

namespace ZombieRun
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/Game", order = 51)]
    public class GameData : ScriptableObject
    {
        public float groupForwardSpeed = 1f;
        public float stackingRadius = 3f;
        public float controlSensitivity = 1f;
    }
}