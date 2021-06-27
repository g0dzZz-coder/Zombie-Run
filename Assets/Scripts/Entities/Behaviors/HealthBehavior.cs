namespace ZombieRun.Entities
{
    using Player;

    public class HealthBehavior : EntityBehavior
    {
        public override void Init(Player player)
        {
            Player = player;
        }

        public void Die()
        {
            Destroy(gameObject);

            Player.OnCharacterDied();
        }
    }
}