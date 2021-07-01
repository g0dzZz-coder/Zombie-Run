using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Player
{
    using Entities.Characters;
    using Levels;
    using Misc;
    using Utils;

    public class Player : MonoSingleton<Player>
    {
        [SerializeField] private PlayerData _data = null;
        [SerializeField] private StackingTrigger _stackRoot = null;

        public List<Character> Characters { get; private set; } = new List<Character>();

        public PlayerData Data => _data;
        public Transform Root => _stackRoot.transform;

        public event Action CharactersChanged;

        public void AddToGroup(Character teammate)
        {
            if (Characters.Contains(teammate))
                return;

            teammate.transform.SetParent(Root);
            teammate.OnStacked(this);

            Characters.Add(teammate);
            CharactersChanged?.Invoke();
        }

        public void RemoveFromGroup(Character character)
        {
            if (Characters.Contains(character) == false)
                return;

            Characters.Remove(character);
            CharactersChanged?.Invoke();

            if (Characters.Count == 0)
                LevelLogic.Instance.EndLevel(false);
        }

        public void SetPosition(Vector3 position)
        {
            Root.position = position;
        }

        protected override void OnAwake()
        {
            _stackRoot.Init(this, GameLogic.Instance.Data.stackingRadius);
        }
    }
}