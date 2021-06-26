using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZombieRun.Player
{
    using Entities;
    using Input;

    [RequireComponent(typeof(IInputProvider))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerData _data = null;

        [Header("Events")]
        [SerializeField] private GameEvent _onPlayerDied = null;

        public List<Character> Characters { get; private set; } = new List<Character>();

        private IInputProvider _inputProvider;
        private Collider _target;

        private void OnTriggerEnter(Collider other)
        {
            if (other == _target)
            {
                //_movementController.StopMove();
            }
        }

        public void Init()
        {
            _inputProvider = GetComponent<IInputProvider>();

            CreateCharacter();
        }

        private void AddTeammate(Character teammate)
        {
            Characters.Add(teammate);
        }

        public void Die()
        {
            _onPlayerDied?.Raise();
        }

        private void CreateCharacter()
        {
            var character = Instantiate(_data.character.prefab, transform);
            character.Init(_data.character, _inputProvider, _data.movement);

            Characters.Add(character);
        }
    }
}