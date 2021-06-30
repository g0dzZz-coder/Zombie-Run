using Lean.Pool;
using UnityEngine;

namespace ZombieRun.Entities.Weapon
{
    using Misc;
    using Enemies;

    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [Range(0f, 100f)]
        [SerializeField] private float _velocity = 50f;
        [SerializeField] private GameObject _trailPrefab = null;
        [SerializeField] private Effect _hitEffect = null;

        private int _damage;
        private LayerMask _targetLayers;

        private void OnTriggerEnter(Collider collision)
        {
            if (((1 << collision.gameObject.layer) & _targetLayers) == 0)
                return;

            if (collision.gameObject.TryGetComponent(out EnemyHealth health) == false)
                return;

            health.TakeDamage(_damage);
            CreateHitEffect();

            LeanPool.Despawn(gameObject);
        }

        public void Init(LayerMask layers, int damage)
        {
            _targetLayers = layers;
            _damage = damage;

            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.rotation * Vector3.forward * _velocity, ForceMode.Impulse);

            CreateTrail();
        }

        private void CreateHitEffect()
        {
            if (_hitEffect == null)
                return;

            var hitObj = LeanPool.Spawn(_hitEffect.prefab, transform.position, transform.rotation, null);
            LeanPool.Despawn(hitObj, _hitEffect.lifeTime);
        }

        private void CreateTrail()
        {
            if (_trailPrefab == null)
                return;

            LeanPool.Spawn(_trailPrefab, transform.position, transform.rotation, transform);
        }
    }
}