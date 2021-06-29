using System;
using UnityEngine;

namespace ZombieRun.Misc
{
    using Entities;

    public class DetectionTrigger : Trigger<SphereCollider>
    {
        public event Action<Transform> Detected;
        public event Action<Transform> Undetected;

        private Transform _lastDetected;

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out StackableCharacterController character))
            {
                if (character.Player == null)
                    return;

                _lastDetected = character.transform;
                Detected?.Invoke(_lastDetected);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform == _lastDetected)
            {
                Undetected?.Invoke(_lastDetected);
                _lastDetected = null;
            }
        }

        public void Setup(float radius)
        {
            Collider.radius = radius;
        }
    }
}