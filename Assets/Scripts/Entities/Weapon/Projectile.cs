using System.Collections;
using UnityEngine;

namespace ZombieRun.Entities.Weapon
{
    using Misc;

    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [Range(0f, 100f)]
        [SerializeField] private float _velocity = 50f;
        [Range(1f, 10f)]
        [SerializeField] private float _lifeTime = 5f;

        [SerializeField] private GameObject _trailPrefab = null;
        [SerializeField] private Effect _hitEffect = null;

        private int _damage;
        private LayerMask _targetLayers;

        private void OnTriggerEnter(Collider collision)
        {
            if (((1 << collision.gameObject.layer) & _targetLayers) == 0)
                return;

            if (collision.gameObject.TryGetComponent(out Health health) == false)
                return;

            health.TakeDamage(_damage);
            CreateHitEffect();
            Destroy(gameObject);
        }

        public void Init(LayerMask layers, int damage)
        {
            _targetLayers = layers;
            _damage = damage;

            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.rotation * Vector3.forward * _velocity, ForceMode.Impulse);

            CreateTrail();
            StartCoroutine(DestroyEffect(gameObject, _lifeTime));
        }

        private void CreateHitEffect()
        {
            if (_hitEffect == null)
                return;

            var effect = Instantiate(_hitEffect.prefab, transform.position, transform.rotation, null);
            StartCoroutine(DestroyEffect(effect, _hitEffect.lifeTime));
        }

        private void CreateTrail()
        {
            if (_trailPrefab == null)
                return;

            Instantiate(_trailPrefab, transform.position, Quaternion.identity, transform);
        }

        private IEnumerator DestroyEffect(GameObject obj, float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(obj);
        }
    }
}