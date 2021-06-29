using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Entities
{
    public class StackableCharacter : EntityBase
    {
        [SerializeField] private CharacterData _data = null;

        [SerializeField] private Animator _animator = null;
        [SerializeField] private Renderer _renderer = null;

        [SerializeField] private EntityBehavior[] _behaviors = null;

        private void Start()
        {
            foreach (var behavior in _behaviors)
                behavior.Init(this);

            SetMaterial(_data.material);

            StopRun();
        }

        public void OnStacked(Material material)
        {
            SetMaterial(material);
            StartRun();
        }

        public void OnUnstacked()
        {
            //StopRun();
        }

        private void StartRun()
        {
            _animator.SetBool("IsRun", true);
        }

        private void StopRun()
        {
            _animator.SetBool("IsRun", false);
        }

        private void SetMaterial(Material material)
        {
            _renderer.material = material;
        }
    }
}