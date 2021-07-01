using UnityEngine;

namespace ZombieRun.Entities.Enemies
{
    using UI;

    public class EnemyView : EntityViewBase
    {
        [SerializeField] private Renderer _renderer = null;
        [SerializeField] private HealthBarUI _healthBar = null;

        public void Init(Enemy enemy)
        {
            SetMaterial(enemy.Data.material);
            _healthBar.Init(enemy.Data.health);
        }

        public void OnHealthChanged(int currentHealth)
        {
            _healthBar.UpdateProgressFill(currentHealth);
        }

        public void OnDamageTaked()
        {
            animator.SetTrigger("OnHit");
        }

        public void OnRunStarted()
        {
            animator.SetBool("IsRun", true);
        }

        public void OnRunEnded()
        {
            animator.SetBool("IsRun", false);
        }

        public void OnSpeedChanged(float value)
        {
            animator.SetFloat("Speed", value);
        }

        private void SetMaterial(Material material)
        {
            _renderer.material = material;
        }
    }
}