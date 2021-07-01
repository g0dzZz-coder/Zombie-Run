using UnityEngine;

namespace ZombieRun.Misc
{
    using Player;
    using Levels;

    public class EndLevelTrigger : Trigger<Collider>
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (LevelLogic.Instance.IsStarted == false)
                return;

            if (other.TryGetComponent(out PlayerMovementController player) == false)
                return;

            player.StopRun();
            LevelLogic.Instance.EndLevel(true);
        }
    }
}