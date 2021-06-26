using UnityEngine;

namespace ZombieRun.Levels
{
    using Player;

    public class StartZone : MonoBehaviour
    {
        public Player CreatePlayer(Player prefab)
        {
            var player = Instantiate(prefab, GameLogic.Instance.Root);
            player.transform.position = transform.position;

            player.Init();

            return player;
        }
    }
}