using System;
using UnityEngine;

namespace ZombieRun.Misc
{
    using Entities.Characters;

    [RequireComponent(typeof(SphereCollider))]
    public class DetectionTrigger : Trigger<SphereCollider>
    {
        public event Action<Transform> Detected;
        public event Action Undetected;

        private Transform _lastDetected;

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character character) == false)
                return;

            if (character.Player == null)
                return;

            _lastDetected = character.transform;
            Detected?.Invoke(_lastDetected);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform != _lastDetected)
                return;

            Undetected?.Invoke();
            _lastDetected = null;
        }

        public void Setup(float radius)
        {
            Collider.radius = radius;
        }
    }
}