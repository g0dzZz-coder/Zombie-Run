using UnityEngine;

namespace ZombieRun.Entities
{
    using Characters;
    using Misc;

    [RequireComponent(typeof(Collider))]
    public class Obstacle : Trigger<Collider>
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterHealth character))
                character.Die(-other.transform.forward);
        }
    }
}