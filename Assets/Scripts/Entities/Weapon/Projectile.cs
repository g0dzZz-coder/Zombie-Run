using UnityEngine;

namespace ZombieRun.Entities.Weapon
{
    using Misc;

    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _velocity = 1f;

        [SerializeField] private GameObject _trailPrefab = null;
        [SerializeField] private GameObject _hitEffectPrefab = null;

        public float Damage { get; private set; }

        private void Start()
        {
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = transform.rotation * Vector3.forward * _velocity;

            CreateTrail();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out StackableCharacterController health))
            {
                health.Die();
            }

            CreateHitEffect();
            Destroy(gameObject);
        }

        private void CreateHitEffect()
        {
            if (_hitEffectPrefab == null)
                return;

            Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
        }

        private void CreateTrail()
        {
            if (_trailPrefab == null)
                return;

            Instantiate(_trailPrefab, transform.position, Quaternion.identity, transform);
        }
    }
}