using UnityEngine;

namespace ZombieRun.Entities
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Entities/Enemy", order = 51)]
    public class EnemyData : EntityData
    {
        public int health = 100;
        public float movementSpeed = 1f;
        public float detectionRadius = 5f;
    }
}