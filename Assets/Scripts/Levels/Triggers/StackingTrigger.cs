using UnityEngine;

namespace ZombieRun.Levels.Triggers
{
    using Entities;
    using Player;

    [RequireComponent(typeof(SphereCollider))]
    public class StackingTrigger : Trigger<SphereCollider>
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out StackableCharacter character))
            {
                Player.Instance.AddToGroup(character);
            }
        }

        public void SetRadius(float radius)
        {
            Collider.radius = radius;
        }
    }
}