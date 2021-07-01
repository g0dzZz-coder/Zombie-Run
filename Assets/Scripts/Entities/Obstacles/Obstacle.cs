using UnityEngine;

namespace ZombieRun.Entities
{
    using Characters;

    [RequireComponent(typeof(Collider))]
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterHealth character))
                character.Die();
        }
    }
}