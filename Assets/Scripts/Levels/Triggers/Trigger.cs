using UnityEngine;

namespace ZombieRun.Levels.Triggers
{
    [RequireComponent(typeof(Collider))]
    public class Trigger : MonoBehaviour
    {
        private Collider _collider;

        protected void Awake()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }
    }
}