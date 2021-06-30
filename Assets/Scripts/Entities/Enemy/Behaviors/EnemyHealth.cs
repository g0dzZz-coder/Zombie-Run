using System;

namespace ZombieRun.Entities.Enemies
{
    public class EnemyHealth : EnemyBehaviorBase
    {
        public int CurrentHealth { get; private set; }

        public event Action<int> HealthChanged;
        public event Action DamageTaked;

        public void TakeDamage(int damageAmount)
        {
            if (damageAmount < 0)
                return;

            CurrentHealth -= damageAmount;

            DamageTaked?.Invoke();
            HealthChanged?.Invoke(CurrentHealth);

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                Die();
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        protected override void OnInited()
        {
            CurrentHealth = Source.Data.health;

            DamageTaked += Source.View.OnDamageTaked;
            HealthChanged += Source.View.OnHealthChanged;
        }

        private void OnDestroy()
        {
            DamageTaked -= Source.View.OnDamageTaked;
            HealthChanged -= Source.View.OnHealthChanged;
        }
    }
}