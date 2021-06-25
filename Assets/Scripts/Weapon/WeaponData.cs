using UnityEngine;

namespace ZombieRun
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/Weapon", order = 51)]

    public class WeaponData : ScriptableObject
    {
        public float fireRate = 1f;
        public float accuracy = 0.8f;
        public float damage = 1f;
        public float range = 5f;
    }
}