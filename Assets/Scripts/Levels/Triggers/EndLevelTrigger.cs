using UnityEngine;

namespace ZombieRun.Misc
{
    using Entities.Characters;
    using Player;

    public class EndLevelTrigger : Trigger<Collider>
    {
        protected override void OnTriggerEnter(Collider other)
        {
            //if (other.TryGetComponent(out Character character))
            //{
            //    character.SetTarget(null);
            //    GameLogic.Instance.EndGame(true);
            //}

            if (other.TryGetComponent(out PlayerMovementController player))
            {
                player.StopRun();
                GameLogic.Instance.EndGame(true);
            }
        }
    }
}