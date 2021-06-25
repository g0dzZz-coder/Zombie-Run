using UnityEngine;

namespace ZombieRun
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/Enemy", order = 51)]
    public class EnemyData : ScriptableObject
    {
        public int health = 100;
        public float movementSpeed = 1f;
        public float detectionRadius = 5f;
    }
}