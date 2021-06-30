using UnityEngine;
using System;

namespace ZombieRun.Entities.Enemies
{
    using Player;

    [RequireComponent(typeof(Collider))]
    public class Enemy : EntityBase<EnemyData>
    {
        [SerializeField] private EnemyView _view = null;
        [SerializeField] private EnemyBehaviorBase[] _behaviors = null;

        public EnemyView View => _view;

        public Action Stuned { get; set; }

        private void Start()
        {
            transform.LookAt(Player.Instance.Root);

            _view.Init(this);

            foreach (EnemyBehaviorBase behavior in _behaviors)
            {
                if (behavior == null)
                    continue;

                behavior.Init(this);
            }
        }
    }
}