using UnityEngine;

namespace ZombieRun.Entities
{
    public abstract class EntityData : ScriptableObject
    {
        public Material material = null;
    }

    public abstract class EntityBase : MonoBehaviour
    {
        
    }
}
