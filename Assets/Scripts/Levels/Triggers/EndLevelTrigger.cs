using UnityEngine;

namespace ZombieRun.Misc
{
    using Entities;

    public class EndLevelTrigger : Trigger<Collider>
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out StackableCharacterController character))
            {
                character.StopRun();
                GameLogic.Instance.EndGame(true);
            }
        }
    }
}