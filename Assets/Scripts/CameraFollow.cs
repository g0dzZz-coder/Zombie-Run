using System;
using UnityEngine;

namespace ZombieRun.Cameras
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _target = null;
        [SerializeField] private float _smoothSpeed = 0.125f;
        [SerializeField] private float _offset = 15f;

        private void LateUpdate()
        {
            if (_target == null)
                return;

            FollowTo(_target);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void FollowTo(Transform target)
        {
            var desiredPosition = target.position.x - _offset;
            var smoothedPosition = Mathf.Lerp(transform.position.x, desiredPosition, _smoothSpeed);
            transform.position = new Vector3(smoothedPosition, transform.position.y, transform.position.z);
        }

        private void OnValidate()
        {
            if (_camera == null)
                throw new NullReferenceException($"{nameof(Camera)} is empty!");
        }
    }
}