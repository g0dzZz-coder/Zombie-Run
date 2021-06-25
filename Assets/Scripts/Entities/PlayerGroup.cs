using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Entities
{
    public class PlayerGroup : MonoBehaviour
    {
        [SerializeField] private Character _characterPrefab = null;

        private List<Character> _characters = new List<Character>();

        public void Init()
        {
            CreateCharacter();
        }

        private void CreateCharacter()
        {
            var character = Instantiate(_characterPrefab, transform);
            _characters.Add(character);
        }
    }
}