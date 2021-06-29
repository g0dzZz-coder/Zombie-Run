using UnityEngine;

namespace ZombieRun.Levels.Triggers
{
    public abstract class Trigger<T> : MonoBehaviour where T : Collider
    {
        protected T Collider
        {
            get
            {
                if (_collider == null)
                {
                    _collider = GetComponent<T>();
                    _collider.isTrigger = true;
                }

                return _collider;
            }
        }

        private T _collider;
    }
}