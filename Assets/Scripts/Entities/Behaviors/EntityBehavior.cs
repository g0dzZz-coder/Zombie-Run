using UnityEngine;

namespace ZombieRun.Entities
{
    using Player;

    public abstract class EntityBehavior : MonoBehaviour
    {
        public abstract void Init(Player player);
    }
}