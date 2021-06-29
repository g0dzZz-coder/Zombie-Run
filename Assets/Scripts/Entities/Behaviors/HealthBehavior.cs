namespace ZombieRun.Entities
{
    using Player;

    public class HealthBehavior : EntityBehavior
    {
        public override void OnInited()
        {

        }

        public void Die()
        {
            Player.Instance.RemoveFromGroup(Source as StackableCharacter);

            Destroy(gameObject);
        }
    }
}