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

        public void OnDying(Vector3 direction)
        {
            var effect = LeanPool.Spawn(_deathEffect.prefab, transform.position, Quaternion.FromToRotation(Vector3.forward, direction));
            LeanPool.Despawn(effect, _deathEffect.lifeTime);
        }
    }
}