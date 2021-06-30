using UnityEngine;

namespace ZombieRun.Entities.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Settings/Weapon", order = 51)]
    public class WeaponData : ScriptableObject
    {
        public Projectile bulletPrefab = null;

        [Range(10f, 1000f)]
        public float fireRate = 1f;

        [Range(0f, 1f)]
        public float accuracy = 0.8f;

        [Range(0, 10)]
        public int damage = 1;

        [Range(1f, 20f)]
        public float range = 5f;
    }
}