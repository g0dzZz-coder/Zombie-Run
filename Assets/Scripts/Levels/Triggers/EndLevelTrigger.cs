using UnityEngine;

namespace ZombieRun.Levels.Triggers
{
    using Entities;

    public class EndLevelTrigger : Trigger
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out MovementBehavior character))
            {
                character.StopRun();
                GameLogic.Instance.EndGame(true);
            }
        }
    }
}