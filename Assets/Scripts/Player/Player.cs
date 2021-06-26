using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Player
{
    using Entities;
    using Input;
    using Misc;

    [RequireComponent(typeof(IInputProvider))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerData _data = null;

        [Header("Events")]
        [SerializeField] private GameEvent _onPlayerDied = null;

        public List<Character> Characters { get; private set; } = new List<Character>();
        public Collider Target { get; private set; }

        private IInputProvider _inputProvider;

        public void Init()
        {
            _inputProvider = GetComponent<IInputProvider>();

            CreateCharacter();
        }

        public void SetTarget(Collider target)
        {
            Target = target;
        }

        private void AddTeammate(Character teammate)
        {
            Characters.Add(teammate);
        }

        public void Die()
        {
            _onPlayerDied?.Invoke();
        }

        private void CreateCharacter()
        {
            var character = Instantiate(_data.character.prefab, transform);
            character.Init(this, _inputProvider, _data.movement);

            Characters.Add(character);
        }
    }
}