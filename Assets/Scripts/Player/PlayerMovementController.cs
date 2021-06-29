using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Player
{
    using Input;
    using ZombieRun.Entities;

    [RequireComponent(typeof(IInputProvider))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Player _player = null;
        [SerializeField] private GameData _data = null;
        [SerializeField] private CharacterController _controller = null;

        private bool _isRunning;
        private List<MovementBehavior> _targets = new List<MovementBehavior>();
        private IInputProvider _inputProvider;

        private void Awake()
        {
            _inputProvider = GetComponent<IInputProvider>();
            StartRun();
        }

        private void OnEnable()
        {
            _player.CharactersChanged += SetTargets;
        }

        private void OnDisable()
        {
            _player.CharactersChanged -= SetTargets;
        }

        private void Update()
        {
            if (_isRunning == false || _targets == null || _targets.Count == 0)
                return;

            Move();
            foreach (var target in _targets)
            {
                target.Rotate(_inputProvider.GetDirection());
                //target.Move();
            }
        }

        public void SetTargets(List<StackableCharacter> characters)
        {
            _targets.Clear();
            foreach (var character in characters)
            {
                if (character.TryGetComponent(out MovementBehavior movement) == false)
                    return;

                movement.StartRun();
                _targets.Add(movement);
            }
        }

        public void StartRun()
        {
            foreach (var target in _targets)
                target.StartRun();

            _isRunning = true;
        }

        public void StopRun()
        {
            foreach (var target in _targets)
                target.StopRun();

            _isRunning = false;
        }

        public void Move()
        {
            var direction = _inputProvider.GetDirection();
            var targetAngle = direction.z * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            var motion = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _controller.Move(motion.normalized * _data.movement.moveSpeed * Time.deltaTime);
        }
    }
}