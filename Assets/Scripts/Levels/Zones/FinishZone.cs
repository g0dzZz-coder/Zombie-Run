using UnityEngine;

namespace ZombieRun.Levels
{
    using Entities;

    [RequireComponent(typeof(Collider))]
    public class FinishZone : MonoBehaviour
    {
        private Collider _collider;

        public void Init()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                GameLogic.Instance.EndGame(true);
            }
        }
    }
}