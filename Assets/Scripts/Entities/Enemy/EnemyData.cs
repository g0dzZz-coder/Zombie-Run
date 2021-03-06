using UnityEngine;

namespace ZombieRun.Entities
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Entities/Enemy", order = 51)]
    public class EnemyData : EntityData
    {
        [Range(0, 10)]
        public int health = 10;

        public MovementSettings movement = new MovementSettings();

        [Range(0f, 10f)]
        public float detectionRadius = 5f;

        [Range(0f, 2f)]
        public float stunDuration = 0.75f;

        public float MoveSpeed => movement.moveSpeed.value;
        public float TurnSpeed => movement.turnSpeed;
    }
}