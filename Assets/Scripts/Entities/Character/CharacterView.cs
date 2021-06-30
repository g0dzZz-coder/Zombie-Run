using UnityEngine;

namespace ZombieRun.Entities
{
    public class CharacterView : EntityViewBase
    {
        [SerializeField] private Renderer _renderer = null;

        public void OnStacked(Material material)
        {
            SetMaterial(material);

            animator.SetTrigger("OnStacked");
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