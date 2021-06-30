using UnityEngine;

namespace ZombieRun.Entities
{
    public class EnemyView : EntityViewBase
    {
        [SerializeField] private Renderer _renderer = null;

        private EnemyController _controller;

        public void Init(EnemyController controller)
        {
            _controller = controller;
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

        private void SetMaterial(Material material)
        {
            _renderer.material = material;
        }
    }
}