using System;
using UnityEngine;

namespace ZombieRun.Entities
{
    public interface IEntityController
    {
        //event Action Dead;
    }

    public abstract class EntityControllerBase<T> : MonoBehaviour, IEntityController where T : EntityData
    {
        [SerializeField] private T _data = null;

        public T Data => _data;
    }
}
