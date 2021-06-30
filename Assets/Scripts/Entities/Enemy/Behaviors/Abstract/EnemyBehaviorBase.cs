using UnityEngine;

namespace ZombieRun.Entities.Enemies
{
    [RequireComponent(typeof(Enemy))]
    public abstract class EnemyBehaviorBase : MonoBehaviour
    {
        protected Enemy Source { get; set; }

        public void Init(Enemy source)
        {
            Source = source;
            OnInited();
        }

        protected abstract void OnInited();
    }
}