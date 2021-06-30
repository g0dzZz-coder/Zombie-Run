using UnityEngine;

namespace ZombieRun.Entities.Enemies
{
    using Characters;

    public class EnemyAttack : EnemyBehaviorBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterHealth character))
            {
                Attack(character);
            }
        }

        private void Attack(CharacterHealth target)
        {
            target.Die();
        }

        protected override void OnInited() { }
    }
}