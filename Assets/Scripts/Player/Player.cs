using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Player
{
    using Entities;
    using Levels.Triggers;
    using Utils;

    public class Player : MonoSingleton<Player>
    {
        [SerializeField] private PlayerData _data = null;
        [SerializeField] private GameData _gameData = null;
        [SerializeField] private StackingTrigger _stackRoot = null;

        public List<StackableCharacter> Characters { get; private set; } = new List<StackableCharacter>();
        public Transform Root => _stackRoot.transform;

        public Material Material => _data.material;

        public event Action<List<StackableCharacter>> CharactersChanged;

        private void Awake()
        {
            OnAwake();
            Init();
        }

        public void AddToGroup(StackableCharacter teammate)
        {
            if (Characters.Contains(teammate))
                return;

            teammate.transform.SetParent(Root);
            teammate.OnStacked(_data.material);

            Characters.Add(teammate);
            CharactersChanged?.Invoke(Characters);
        }

        public void RemoveFromGroup(StackableCharacter character)
        {
            if (Characters.Contains(character) == false)
                return;

            Characters.Remove(character);
            CharactersChanged?.Invoke(Characters);

            if (Characters.Count == 0)
                GameLogic.Instance.RestartGame();
        }

        public void RemoveAllCharacters()
        {
            foreach (var character in Characters)
                Destroy(character.gameObject);

            Characters.Clear();
            CharactersChanged?.Invoke(Characters);
        }

        public void SetPosition(Vector3 position)
        {
            Root.position = position;
        }

        private void Init()
        {
            _stackRoot.Init(this, _gameData.stackingRadius);
        }
    }
}