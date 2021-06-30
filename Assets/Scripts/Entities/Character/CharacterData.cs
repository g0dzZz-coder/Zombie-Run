using UnityEngine;

namespace ZombieRun.Entities
{
    using Weapon;

    [CreateAssetMenu(fileName = "Character", menuName = "Entities/Character", order = 51)]
    public class CharacterData : EntityData
    {
        public CharacterController prefab = null;

        [Range(1, 3)]
        public int health = 1;

        public WeaponData weapon = null;
    }
}