using UnityEngine;

namespace ZombieRun.Entities
{
    using Input;
    using Player;

    public class MovementBehavior : EntityBehavior
    {
        [SerializeField] private GameData _data = null;
        [SerializeField] private CharacterController _controller = null;
        [SerializeField] private Animator _animator = null;

        private float _turnSmoothVelocity;
        private float _targetAngle;
        private bool _isRunning;

        private IInputProvider _inputProvider;

        private void Awake()
        {
            _inputProvider = GetComponentInParent<IInputProvider>();

            StopRun();
            Rotate(Camera.main.transform.forward);
        }

        private void Update()
        {
            if (_isRunning == false || _inputProvider == null)
                return;

            Rotate(_inputProvider.GetDirection());
            Move();
        }

        public override void Init(Player player)
        {
            _inputProvider = player.InputProvider;
            StartRun();
        }

        public void StartRun()
        {
            _animator.SetBool("IsRun", true);
            _isRunning = true;
        }

        public void StopRun()
        {
            _animator.SetBool("IsRun", false);
            _isRunning = false;
        }

        private void Rotate(Vector3 direction)
        {
            _targetAngle = direction.z * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _data.movement.turnSpeed);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        private void Move()
        {
            var motion = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
            _controller.Move(motion.normalized * _data.movement.moveSpeed * Time.deltaTime);
        }
    }
}