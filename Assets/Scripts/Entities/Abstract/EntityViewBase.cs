using Lean.Pool;
using UnityEngine;

namespace ZombieRun.Entities
{
    using Misc;

    [RequireComponent(typeof(Animator))]
    public abstract class EntityViewBase : MonoBehaviour
    {
        [SerializeField] protected Animator animator = null;
        [SerializeField] private Effect _deathEffect = null;

        public void OnDying()
        {
            var effect = LeanPool.Spawn(_deathEffect.prefab, transform.position, transform.rotation);
            LeanPool.Despawn(effect, _deathEffect.lifeTime);
        }
    }
}