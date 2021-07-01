using System;
using UnityEngine;

namespace ZombieRun.Entities.Enemies
{
    public class EnemyHealth : EnemyBehaviorBase
    {
        public int CurrentHealth { get; private set; }

        public event Action<int> HealthChanged;
        public event Action DamageTaked;

        public void TakeDamage(int damage, Vector3 hitDirection)
        {
            if (damage < 0)
                return;

            CurrentHealth -= damage;

            DamageTaked?.Invoke();
            HealthChanged?.Invoke(CurrentHealth);

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                Die(hitDirection);
            }
        }

        public void Die(Vector3 hitDirection)
        {
            Source.OnDying(hitDirection);
        }

        protected override void OnInited()
        {
            CurrentHealth = Source.Data.health;

            DamageTaked += Source.View.OnDamageTaked;
            DamageTaked += Source.StunStarted;
            HealthChanged += Source.View.OnHealthChanged;
        }

        private void OnDestroy()
        {
            if (IsInited == false)
                return;

            DamageTaked -= Source.View.OnDamageTaked;
            DamageTaked -= Source.StunStarted;
            HealthChanged -= Source.View.OnHealthChanged;
        }
    }
}