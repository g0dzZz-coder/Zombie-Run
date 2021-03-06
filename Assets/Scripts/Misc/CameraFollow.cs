using System;
using UnityEngine;

namespace ZombieRun.Misc
{
    using Player;
    using Utils;

    public class CameraFollow : MonoSingleton<CameraFollow>
    {
        [SerializeField] private Camera _camera;
        [Range(0f, 1f)]
        [SerializeField] private float _smoothSpeed = 0.125f;
        [Range(5f, 50f)]
        [SerializeField] private float _offset = 17.5f;

        public Camera Camera => _camera;

        private void LateUpdate()
        {
            FollowTo(Player.Instance.Root);
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