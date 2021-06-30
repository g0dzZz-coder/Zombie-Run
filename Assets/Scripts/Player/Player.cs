using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Player
{
    using Entities;
    using Misc;
    using Utils;

    public class Player : MonoSingleton<Player>
    {
        [SerializeField] private PlayerData _data = null;
        [SerializeField] private GameData _gameData = null;
        [SerializeField] private StackingTrigger _stackRoot = null;

        public List<StackableCharacterController> Characters { get; private set; } = new List<StackableCharacterController>();

        public PlayerData Data => _data;
        public Transform Root => _stackRoot.transform;

        public event Action<List<StackableCharacterController>> CharactersChanged;

        private void Awake()
        {
            OnAwake();
            Init();
        }

        public void AddToGroup(StackableCharacterController teammate)
        {
            if (Characters.Contains(teammate))
                return;

            teammate.transform.SetParent(Root);
            teammate.OnStacked(this);

            Characters.Add(teammate);
            CharactersChanged?.Invoke(Characters);
        }

        public void RemoveFromGroup(StackableCharacterController character)
        {
            if (Characters.Contains(character) == false)
                return;

            Characters.Remove(character);
            CharactersChanged?.Invoke(Characters);

            if (Characters.Count == 0)
            {
                RemoveAllCharacters();
                GameLogic.Instance.EndGame(false);
            }
        }
        public void SetPosition(Vector3 position)
        {
            Root.position = position;
        }

        private void Init()
        {
            _stackRoot.Init(this, _gameData.stackingRadius);
        }

        private void RemoveAllCharacters()
        {
            foreach (var character in Characters)
                Destroy(character.gameObject);

            Characters.Clear();
            CharactersChanged?.Invoke(Characters);
        }
    }
}