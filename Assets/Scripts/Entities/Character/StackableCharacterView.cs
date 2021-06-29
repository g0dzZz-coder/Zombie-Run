using UnityEngine;

namespace ZombieRun.Entities
{
    public class StackableCharacterView : EntityViewBase
    {
        [SerializeField] private Renderer _renderer = null;
        [SerializeField] private GameObject _deathEffectPrefab = null;

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

        public void OnDying()
        {
            if (_deathEffectPrefab)
                CreateEffect(transform);
        }

        private void SetMaterial(Material material)
        {
            _renderer.material = material;
        }

        private void CreateEffect(Transform transform)
        {
            Instantiate(_deathEffectPrefab, transform.position, transform.rotation);
        }
    }
}