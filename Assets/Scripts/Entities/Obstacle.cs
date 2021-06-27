using UnityEngine;

namespace ZombieRun.Entities
{
    [RequireComponent(typeof(Collider))]
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HealthBehavior character))
            {
                character.Die();
            }
        }
    }
}