using UnityEngine;

namespace ZombieRun.Entities.Characters
{
    public class CharacterHealth : CharacterBehaviorBase
    {
        public void Die(Vector3 hitDirection)
        {
            Source.OnDying(hitDirection);
        }

        protected override void OnInited() { }
    }
}