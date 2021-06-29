using UnityEngine;

namespace ZombieRun.Levels.Triggers
{
    using Entities;

    public class EndLevelTrigger : Trigger<Collider>
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