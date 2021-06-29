using UnityEngine;

namespace ZombieRun.Entities
{
    public class Enemy : EntityBase
    {
        [SerializeField] private EnemyData _data = null;
        [SerializeField] private Renderer _renderer = null;

        private void Awake()
        {
            SetMaterial(_data.material);
        }

        private void SetMaterial(Material material)
        {
            _renderer.material = material;
        }
    }
}