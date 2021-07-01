using UnityEngine;

namespace ZombieRun.Entities.Characters
{
    public class CharacterMovement : CharacterBehaviorBase
    {
        [SerializeField] private CharacterController _controller = null;
        [Range(1f, 2f)]
        [SerializeField] private float _stopDistance = 1.25f;

        private MovementSettings _settings;
        private float _turnSmoothVelocity;
        private float _targetAngle;

        private Transform _target;

        private void Update()
        {
            if (_target == null)
                return;

            MoveTowards(_target);
        }

        private void OnDestroy()
        {
            Source.TargetChanged -= OnTargetChanged;
            Source.DirectionChanged -= Rotate;
        }

        protected override void OnInited()
        {
            _settings = GameLogic.Instance.Data.movement;
            Source.View.OnSpeedChanged(_settings.moveSpeed.value);

            Source.TargetChanged += OnTargetChanged;
            Source.DirectionChanged += Rotate;
        }

        private void Rotate(Vector3 direction)
        {
            _targetAngle = direction.z * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, (1f - _settings.turnSpeed));
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        private void MoveTowards(Transform target)
        {
            var offset = target.position - transform.position;
            if (offset.magnitude < _stopDistance)
                return;

            var motion = offset.normalized * _settings.moveSpeed.value * Time.deltaTime;
            _controller.Move(motion);
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