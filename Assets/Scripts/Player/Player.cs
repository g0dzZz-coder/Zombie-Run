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

        private List<Character> _characters = new List<Character>();

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
            _characters.Add(teammate);
        }

        public void Die()
        {
            _onPlayerDied?.Raise();
        }

        public Transform GetClosestCharacter()
        {
            return _characters.FirstOrDefault().transform;
        }

        private void CreateCharacter()
        {
            var character = Instantiate(_data.character.prefab, transform);
            character.Init(_data.character, _inputProvider, _data.movement);

            _characters.Add(character);
        }
    }
}