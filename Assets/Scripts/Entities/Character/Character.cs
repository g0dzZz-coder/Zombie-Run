using UnityEngine;

namespace ZombieRun.Entities
{
    using Input;

    public class Character : MonoBehaviour
    {
        [SerializeField] private Animator _animator = null;
        [SerializeField] private MovementController _movementController = null;

        private CharacterData _data;

        public void Init(CharacterData data, IInputProvider inputProvider, MovementSettings movementSettings)
        {
            _data = data;
            _movementController.Init(inputProvider, movementSettings);
        }
    }
}