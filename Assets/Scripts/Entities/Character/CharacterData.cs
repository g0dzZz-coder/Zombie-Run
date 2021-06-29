using UnityEngine;

namespace ZombieRun.Entities
{
    [CreateAssetMenu(fileName = "Character", menuName = "Entities/Character", order = 51)]
    public class CharacterData : EntityData
    {
        public StackableCharacter prefab = null;
        public WeaponData weapon = null;
    }
}