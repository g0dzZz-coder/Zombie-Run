using UnityEngine;

namespace ZombieRun.Entities
{
    public class EnemyAttack : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out StackableCharacterController character))
            {
                Attack(character);
            }
        }

        private void Attack(StackableCharacterController target)
        {
            target.Die();
        }
    }
}