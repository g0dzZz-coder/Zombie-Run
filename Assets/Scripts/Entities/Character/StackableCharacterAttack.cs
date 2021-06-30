using System;
using System.Linq;
using UnityEngine;

namespace ZombieRun.Entities
{
    using Utils;
    using Weapon;

    [RequireComponent(typeof(StackableCharacterController))]
    public class StackableCharacterAttack : MonoBehaviour
    {
        [SerializeField] private WeaponData _weapon = null;
        [SerializeField] private Transform _firePoint = null;
        [SerializeField] private LayerMask _enemyLayer = 0;

        private StackableCharacterController _controller = null;

        private float _nextFire = 0f;
        private float _fireDelay;

        private void Awake()
        {
            _controller = GetComponent<StackableCharacterController>();
            _fireDelay = 1f / (_weapon.fireRate / 60f);
        }

        private void Update()
        {
            if (_controller == null || _controller.Player == null)
                return;

            var closest = GetClosestEnemy();
            if (closest == null)
                return;

            LookAt(closest.transform);

            if (Time.time < _nextFire)
                return;

            _nextFire = Time.time + _fireDelay;
            Attack();
        }

        private void Attack()
        {
            var bullet = Instantiate(_weapon.bulletPrefab, _firePoint.position, _firePoint.rotation);
            bullet.Init(_enemyLayer, _weapon.damage);
        }

        private EnemyController GetClosestEnemy()
        {
            var colliders = Physics.OverlapSphere(transform.position, _weapon.range, _enemyLayer);
            Array.Sort(colliders, new DistanceComparer(transform));
            var enemies = colliders.GetComponents<EnemyController, Collider>();

            return enemies.FirstOrDefault();
        }

        private void LookAt(Transform target)
        {
            transform.LookAt(target.transform);
            //var rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * GameLogic.Instance.Data.TurnSpeed);
        }
    }
}