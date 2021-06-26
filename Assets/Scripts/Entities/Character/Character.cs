using UnityEngine;

namespace ZombieRun.Entities
{
    using Input;
    using Player;

    public class Character : MonoBehaviour
    {
        [SerializeField] private Animator _animator = null;
        [SerializeField] private MovementController _movementController = null;

        public MovementController MovementController => _movementController;

        private Player _player;

        public void Init(Player player, IInputProvider inputProvider, MovementSettings movementSettings)
        {
            _player = player;
            _movementController.Init(inputProvider, movementSettings);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == _player.Target)
            {

            }
        }
    }
}