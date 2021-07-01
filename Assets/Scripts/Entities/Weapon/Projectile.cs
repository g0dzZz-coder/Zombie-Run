using Lean.Pool;
using UnityEngine;

namespace ZombieRun.Entities.Weapon
{
    using Misc;
    using Enemies;
    using Utils;

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Projectile : MonoBehaviour
    {
        [Range(0f, 100f)]
        [SerializeField] private float _velocity = 50f;
        [SerializeField] private Effect _hitEffect = null;
        [SerializeField] private GameObject _trailPrefab = null;

        private int _damage;
        private LayerMask _targetLayers;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);

            if (_targetLayers.IsInLayerMask(other.gameObject) == false)
                return;

            if (other.gameObject.TryGetComponent(out EnemyHealth health))
                OnHittingTheTarget(health);
        }

        public void Init(int damage, Vector3 direction, LayerMask layers)
        {
            _damage = damage;
            _rigidbody.AddForce(direction * _velocity, ForceMode.Impulse);
            _targetLayers = layers;

            CreateTrail();
        }

        private void OnHittingTheTarget(EnemyHealth health)
        {
            health.TakeDamage(_damage);
            CreateHitEffect();

            LeanPool.Despawn(gameObject);
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