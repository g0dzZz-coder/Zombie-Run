using UnityEngine;

namespace ZombieRun.Entities
{
    public abstract class EntityBehavior : MonoBehaviour
    {
        public EntityBase Source { get; protected set; }

        public void Init(EntityBase entity)
        {
            Source = entity;
            OnInited();
        }

        public abstract void OnInited();
    }
}