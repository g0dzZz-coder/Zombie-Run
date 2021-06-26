using UnityEngine;

namespace ZombieRun.Entities
{
    using Input;

    public class MovementController : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller = null;

        private float _turnSmoothVelocity;
        private float _targetAngle;

        private IInputProvider _inputProvider;
        private MovementSettings _settings;

        public void Init(IInputProvider inputProvider, MovementSettings settings)
        {
            _inputProvider = inputProvider;
            _settings = settings;
        }

        private void Update()
        {
            if (_inputProvider == null)
                return;

            Rotate();
            Move();
        }

        public void Rotate()
        {
            var direction = _inputProvider.GetDirection();
            _targetAngle = direction.z * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _settings.turnSpeed);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        private void Move()
        {
            var motion = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
            _controller.Move(motion.normalized * _settings.moveSpeed * Time.deltaTime);
        }
    }
}