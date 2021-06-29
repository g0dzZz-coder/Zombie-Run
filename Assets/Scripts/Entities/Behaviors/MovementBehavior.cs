using UnityEngine;

namespace ZombieRun.Entities
{
    public class MovementBehavior : EntityBehavior
    {
        [SerializeField] private GameData _data = null;
        [SerializeField] private CharacterController _controller = null;

        private float _turnSmoothVelocity;
        private float _targetAngle;
        private bool _isRunning;

        private Transform _target;

        private void Update()
        {
            if ( _target == null)
                return;

            if (Vector3.Distance(transform.position, _target.position) < 1f)
                return;

            var step = _data.movement.moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);

            //Move();
        }

        public override void OnInited()
        {
            StopRun();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void StartRun()
        {
            _isRunning = true;
        }

        public void StopRun()
        {
            _isRunning = false;
        }

        public void Rotate(Vector3 direction)
        {
            _targetAngle = direction.z * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _data.movement.turnSpeed);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        public void Move()
        {
            var motion = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
            _controller.Move(motion.normalized * _data.movement.moveSpeed * Time.deltaTime);
        }
    }
}