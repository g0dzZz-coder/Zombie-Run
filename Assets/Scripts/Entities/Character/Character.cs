using UnityEngine;
using System;

namespace ZombieRun.Entities.Characters
{
    using Player;

    [RequireComponent(typeof(CharacterController))]
    public class Character : EntityBase<CharacterData>
    {
        [SerializeField] private GameData _gameData = null;
        [SerializeField] private CharacterView _view = null;
        [SerializeField] private CharacterBehaviorBase[] _behaviors = null;

        public Player Player { get; private set; }
        public CharacterView View => _view;
        public MovementSettings MovementSettings => _gameData.movement;

        public event Action<Transform> TargetChanged;
        public event Action<Vector3> DirectionChanged;

        private void Start()
        {
            foreach (CharacterBehaviorBase behavior in _behaviors)
            {
                if (behavior == null)
                    continue;

                behavior.Init(this);
            }
        }

        public void OnStacked(Player player)
        {
            Player = player;
            _view.OnStacked(Player.Data.material);
        }

        public void SetTarget(Transform target)
        {
            TargetChanged?.Invoke(target);
        }

        public void SetDirection(Vector3 direction)
        {
            DirectionChanged?.Invoke(direction);
        }

        public void OnDying()
        {
            Player.Instance.RemoveFromGroup(this);
            _view.OnDying();
        }
    }
}