using System;
using UnityEngine;

namespace ZombieRun.Entities
{
    using Misc;

    public class Health : MonoBehaviour
    {
        [SerializeField] private Effect _deathEffect = null;

        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }

        public event Action<int> HealthChanged;
        public event Action DamageTaked;

        public void Init(int startHealth)
        {
            MaxHealth = startHealth;
            CurrentHealth = MaxHealth;
        }

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

        private void Die()
        {
            Destroy(gameObject);
        }

        private void CreateDeathEffect()
        {

        }
    }
}