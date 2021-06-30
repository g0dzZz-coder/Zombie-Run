namespace ZombieRun.Entities.Characters
{
    public class CharacterHealth : CharacterBehaviorBase
    {
        public void Die()
        {
            Source.OnDying();
            Destroy(gameObject);
        }

        protected override void OnInited() { }
    }
}