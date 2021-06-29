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
        public Transform Root => _stackRoot.transform;

        public Material Material => _data.material;

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
            teammate.OnStacked(_data);

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
                GameLogic.Instance.EndGame(false);
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