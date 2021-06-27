using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Player
{
    using Entities;
    using Input;
    using Misc;

    [RequireComponent(typeof(IInputProvider))]
    public class Player : EntityBase<PlayerData>
    {
        [Header("Events")]
        [SerializeField] private GameEvent _onPlayerDied = null;

        public List<Character> Characters { get; private set; } = new List<Character>();
        public IInputProvider InputProvider { get; private set; }

        public Material Material => Data.material;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            CreateCharacter();
            InputProvider = GetComponent<IInputProvider>();

            foreach (Character character in Characters)
            {
                character.Init(this);
            }
        }

        public void AddTeammate(Character teammate)
        {
            if (Characters.Contains(teammate))
                return;

            teammate.Init(this);
            Characters.Add(teammate);
        }

        public void OnCharacterDied()
        {
            if (Characters.Count == 0)
                _onPlayerDied?.Invoke();
        }

        private void CreateCharacter()
        {
            var character = Instantiate(Data.character.prefab, transform);
            Characters.Add(character);
        }
    }
}