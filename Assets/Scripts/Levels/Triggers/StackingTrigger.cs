using UnityEngine;

namespace ZombieRun.Misc
{
    using Entities.Characters;
    using Player;

    [RequireComponent(typeof(SphereCollider))]
    public class StackingTrigger : Trigger<SphereCollider>
    {
        private Player _player;

        protected override void OnTriggerEnter(Collider other)
        {
            if (_player == null)
                return;

            if (other.TryGetComponent(out Character character))
            {
                _player.AddToGroup(character);
            }
        }

        public void Init(Player player, float radius)
        {
            _player = player;
            SetRadius(radius);
        }

        private void SetRadius(float radius)
        {
            Collider.radius = radius;
        }
    }
}