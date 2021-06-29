using UnityEngine;

namespace ZombieRun.Levels.Triggers
{
    using Entities;
    using Player;

    [RequireComponent(typeof(SphereCollider))]
    public class StackingTrigger : Trigger<SphereCollider>
    {
        private Player _player;

        private void OnTriggerEnter(Collider other)
        {
            if (_player == null)
                return;

            if (other.TryGetComponent(out StackableCharacter character))
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