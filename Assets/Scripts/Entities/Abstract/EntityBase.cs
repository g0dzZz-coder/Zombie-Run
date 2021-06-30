using UnityEngine;

namespace ZombieRun.Entities
{
    public abstract class EntityBase<T> : MonoBehaviour where T : EntityData
    {
        [SerializeField] private T _data = null;

        public T Data => _data;
    }
}
