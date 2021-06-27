using UnityEngine;

namespace ZombieRun.Entities
{
    public class Enemy : EntityBase<EntityData>
    {
        [SerializeField] private Renderer _renderer = null;

        private void Awake()
        {
            SetMaterial(Data.material);
        }

        private void SetMaterial(Material material)
        {
            _renderer.material = material;
        }
    }
}