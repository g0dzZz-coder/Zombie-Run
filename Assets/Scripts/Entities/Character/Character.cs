using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Entities
{
    using Player;

    public class Character : EntityBase<CharacterData>
    {
        [SerializeField] private Animator _animator = null;
        [SerializeField] private Renderer _renderer = null;
        [SerializeField] private List<EntityBehavior> _behaviors = new List<EntityBehavior>();

        public Player Player { get; private set; }

        private void Awake()
        {
            SetMaterial(Data.material);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Character character))
            {
                Debug.Log(true);
            }
        }

        public void Init(Player player)
        {
            Player = player;
            SetMaterial(Player.Material);

            foreach (EntityBehavior behavior in _behaviors)
            {
                behavior.Init(Player);
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        private void SetMaterial(Material material)
        {
            _renderer.material = material;
        }
    }
}