using Lean.Pool;
using System;
using System.Linq;
using UnityEngine;

namespace ZombieRun.Entities.Characters
{
    using Enemies;
    using Utils;
    using Weapon;

    [RequireComponent(typeof(CharacterController))]
    public class CharacterAttack : CharacterBehaviorBase
    {
        [SerializeField] private WeaponData _weapon = null;
        [SerializeField] private Transform _firePoint = null;
        [SerializeField] private LayerMask _enemyLayer = 0;

        private Character _controller = null;

        private float _nextFire = 0f;
        private float _fireDelay;

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

        protected override void OnInited()
        {
            _controller = GetComponent<Character>();
            _fireDelay = 1f / (_weapon.fireRate / 60f);
        }

        private void Attack()
        {
            var bullet = LeanPool.Spawn(_weapon.bulletPrefab, _firePoint.position, _firePoint.rotation);
            bullet.Init(_enemyLayer, _weapon.damage);
        }

        private Enemy GetClosestEnemy()
        {
            var colliders = Physics.OverlapSphere(transform.position, _weapon.range, _enemyLayer);
            Array.Sort(colliders, new DistanceComparer(transform));
            var enemies = colliders.GetComponents<Enemy, Collider>();

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