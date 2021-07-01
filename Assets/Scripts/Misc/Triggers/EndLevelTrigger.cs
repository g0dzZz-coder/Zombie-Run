using UnityEngine;

namespace ZombieRun.Misc
{
    using Player;

    public class EndLevelTrigger : Trigger<Collider>
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (GameLogic.Instance.IsStarted == false)
                return;

            if (other.TryGetComponent(out PlayerMovementController player) == false)
                return;

            player.StopRun();
            GameLogic.Instance.EndGame(true);
        }
    }
}