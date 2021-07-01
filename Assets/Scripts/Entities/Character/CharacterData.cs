using UnityEngine;

namespace ZombieRun.Entities
{
    using Weapon;

    [CreateAssetMenu(fileName = "Character", menuName = "Entities/Character", order = 51)]
    public class CharacterData : EntityData
    {
        public CharacterController prefab = null;
        public WeaponData weapon = null;
    }
}