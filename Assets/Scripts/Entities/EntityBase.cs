using UnityEngine;

namespace ZombieRun.Entities
{
    public abstract class EntityData : ScriptableObject
    {
        public Material material = null;
    }

    public abstract class EntityBase<T> : MonoBehaviour where T: EntityData
    {
        [SerializeField] private T _data = null;

        protected T Data => _data;

        //public abstract void OnSpawn();
    }
}
