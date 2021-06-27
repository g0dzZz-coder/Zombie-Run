using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Entities
{
    using Levels.Triggers;
    using Player;

    public class Character : EntityBase<CharacterData>
    {
        [SerializeField] private StackingTrigger _stackingTrigger = null;
        [SerializeField] private Animator _animator = null;
        [SerializeField] private Renderer _renderer = null;
        [SerializeField] private List<EntityBehavior> _behaviors = new List<EntityBehavior>();

        public Player Player { get; private set; }

        private void Awake()
        {
            SetMaterial(Data.material);
            transform.LookAt(Camera.main.transform.forward);
        }

        public void Init(Player player)
        {
            Player = player;
            _stackingTrigger.Init(Player);

            foreach (EntityBehavior behavior in _behaviors)
            {
                behavior.Init(Player);
            }

            SetMaterial(Player.Material);
        }

        private void SetMaterial(Material material)
        {
            _renderer.material = material;
        }
    }
}