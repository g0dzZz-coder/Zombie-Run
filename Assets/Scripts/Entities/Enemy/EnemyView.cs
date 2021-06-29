using UnityEngine;

namespace ZombieRun.Entities
{
    using UI;

    public class EnemyView : EntityViewBase
    {
        [SerializeField] private Renderer _renderer = null;
        [SerializeField] private HealthBarUI _healthBar = null;

        private EnemyController _controller;

        public void Init(EnemyController controller)
        {
            _controller = controller;

            _healthBar.Init(_controller.Health, _controller.Health);
        }

        public void OnDamageTaked(float currentHealth)
        {
            if (_healthBar == null)
                return;

            _healthBar.UpdateProgressFill(currentHealth);
        }

        public void OnRunStarted()
        {
            animator.SetBool("IsRun", true);
        }

        public void OnRunEnded()
        {
            animator.SetBool("IsRun", false);
        }

        private void SetMaterial(Material material)
        {
            _renderer.material = material;
        }
    }
}