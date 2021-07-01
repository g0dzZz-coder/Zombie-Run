using UnityEngine;

namespace ZombieRun.Entities.Enemies
{
    using Characters;

    public class EnemyAttack : EnemyBehaviorBase
    {
        private bool _isCanAttack = true;

        private void OnTriggerEnter(Collider other)
        {
            if (_isCanAttack == false)
                return;

            if (other.TryGetComponent(out CharacterHealth character))
                Attack(character);
        }

        private void OnDestroy()
        {
            if (IsInited == false)
                return;

            Source.StunStarted -= OnStunStarted;
            Source.StunEnded -= OnStunEnded;
        }

        protected override void OnInited()
        {
            Source.StunStarted += OnStunStarted;
            Source.StunEnded += OnStunEnded;
        }

        private void Attack(CharacterHealth target)
        {
            target.Die(transform.forward);
        }

        private void OnStunStarted()
        {
            _isCanAttack = false;
        }

        private void OnStunEnded()
        {
            _isCanAttack = true;
        }
    }
}