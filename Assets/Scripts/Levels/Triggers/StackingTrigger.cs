using UnityEngine;

namespace ZombieRun.Levels.Triggers
{
    using Entities;
    using Player;

    public class StackingTrigger : Trigger
    {
        private Player _player;

        public void Init(Player player)
        {
            _player = player;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_player == null)
                return;

            if (other.TryGetComponent(out Character character))
            {
                _player.AddTeammate(character);
            }
        }
    }
}