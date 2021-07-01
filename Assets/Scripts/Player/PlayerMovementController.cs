using UnityEngine;

namespace ZombieRun.Player
{
    using Entities.Characters;
    using Input;
    using Misc;

    [RequireComponent(typeof(IInputProvider))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Player _player = null;
        [SerializeField] private GameData _data = null;
        [SerializeField] private CharacterController _controller = null;

        private bool _isRunning;
        private IInputProvider _inputProvider;

        private void Start()
        {
            _inputProvider = GetComponent<IInputProvider>();
            StartRun();
        }

        private void OnEnable()
        {
            _player.CharactersChanged += StartRun;
        }

        private void OnDisable()
        {
            _player.CharactersChanged -= StartRun;
        }

        private void Update()
        {
            if (_isRunning == false || _player.Characters == null || _player.Characters.Count == 0)
                return;

            var direction = _inputProvider.GetDirection();
            Move(direction);

            foreach (Character target in _player.Characters)
                target.SetDirection(direction);
        }

        public void StartRun()
        {
            SetTarget(_player.Root);
            _isRunning = true;
        }

        public void StopRun()
        {
            SetTarget(null);
            _isRunning = false;
        }

        public void SetTarget(Transform target)
        {
            foreach (Character character in _player.Characters)
                character.SetTarget(target);
        }

        public void Move(Vector3 direction)
        {
            var targetAngle = direction.z * Mathf.Rad2Deg + CameraFollow.Instance.transform.eulerAngles.y;
            var motion = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            _controller.Move(motion.normalized * _data.MoveSpeed * Time.deltaTime);
        }
    }
}