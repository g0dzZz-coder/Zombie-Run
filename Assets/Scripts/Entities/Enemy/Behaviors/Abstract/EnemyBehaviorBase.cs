using UnityEngine;

namespace ZombieRun.Entities.Enemies
{
    [RequireComponent(typeof(Enemy))]
    public abstract class EnemyBehaviorBase : MonoBehaviour
    {
        protected Enemy Source { get; set; }
        protected bool IsInited { get; set; }

        public void Init(Enemy source)
        {
            Source = source;
            OnInited();

            IsInited = true;
        }

        protected abstract void OnInited();
    }
}