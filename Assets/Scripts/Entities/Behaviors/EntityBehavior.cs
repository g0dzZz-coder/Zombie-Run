using UnityEngine;

namespace ZombieRun.Entities
{
    using Player;

    public abstract class EntityBehavior : MonoBehaviour
    {
        protected Player Player { get; set; }

        public abstract void Init(Player player);
    }
}