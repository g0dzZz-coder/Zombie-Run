using UnityEngine;

namespace ZombieRun.Entities.Characters
{
    using Utils;

    public class CharacterMovement : CharacterBehaviorBase
    {
        [Range(1f, 3f)]
        [SerializeField] private float _stopDistance = 1f;

        private MovementSettings _settings;
        private float _turnSmoothVelocity;
        private float _targetAngle;

        private Transform _target;

        private void Update()
        {
            if (_target == null)
                return;

            Debug.Log(transform.GetDistanceTo(_target));
            if (transform.GetDistanceTo(_target) < _stopDistance)
                return;

            Move();
        }

        private void OnDestroy()
        {
            Source.TargetChanged -= OnTargetChanged;
            Source.DirectionChanged -= Rotate;
        }

        protected override void OnInited()
        {
            _settings = GameLogic.Instance.Data.movement;

            Source.TargetChanged += OnTargetChanged;
            Source.DirectionChanged += Rotate;
        }

        private void Rotate(Vector3 direction)
        {
            _targetAngle = direction.z * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, (1f - _settings.turnSpeed));
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        private void Move()
        {
            var step = _settings.moveSpeed.value * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
        }

        private void OnTargetChanged(Transform target)
        {
            _target = target;

            if (_target)
                StartRun();
            else
                StopRun();
        }

        private void StartRun()
        {
            Source.View.OnRunStarted();
        }

        private void StopRun()
        {
            Source.View.OnRunEnded();
        }
    }
}