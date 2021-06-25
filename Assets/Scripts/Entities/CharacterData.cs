using UnityEngine;

namespace ZombieRun.Entities
{
    [CreateAssetMenu(fileName = "Character", menuName = "Settings/Character", order = 51)]
    public class CharacterData : ScriptableObject
    {
        public Character prefab = null;
    }
}