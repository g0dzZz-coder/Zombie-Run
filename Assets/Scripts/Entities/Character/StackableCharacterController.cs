using UnityEngine;

namespace ZombieRun.Entities
{
    using Player;

    [RequireComponent(typeof(CharacterController))]
    public class StackableCharacterController : EntityControllerBase<StackableCharacterData>
    {
        [SerializeField] private GameData _gameData = null;
        [SerializeField] private StackableCharacterView _view = null;

        private float _turnSmoothVelocity;
        private float _targetAngle;
        private Transform _target;

        private void Update()
        {
            if (_target == null)
                return;

            if (Vector3.Distance(transform.position, _target.position) < 1f)
                return;

            Move();
        }

        public void OnStacked(PlayerData playerData)
        {
            _view.OnStacked(playerData.material);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            StartRun();
        }

        public void Rotate(Vector3 direction)
        {
            _targetAngle = direction.z * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _gameData.TurnSpeed);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        public void Move()
        {
            var step = _gameData.MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
        }

        public void Die()
        {
            _view.OnDying();

            Player.Instance.RemoveFromGroup(this);
            Destroy(gameObject);
        }

        public void StartRun()
        {
            _view.OnRunStarted();
        }

        public void StopRun()
        {
            _view.OnRunEnded();
        }
    }
}