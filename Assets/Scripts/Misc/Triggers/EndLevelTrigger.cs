using UnityEngine;

namespace ZombieRun.Misc
{
    using Player;

    public class EndLevelTrigger : Trigger<Collider>
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMovementController player))
            {
                player.StopRun();
                GameLogic.Instance.EndGame(true);
            }
        }
    }
}