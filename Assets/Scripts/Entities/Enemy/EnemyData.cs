using UnityEngine;

namespace ZombieRun.Entities
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Entities/Enemy", order = 51)]
    public class EnemyData : EntityData
    {
        [Range(0, 10)]
        public int health = 10;
        public MovementSettings movement = new MovementSettings();
        public float detectionRadius = 5f;
    }
}