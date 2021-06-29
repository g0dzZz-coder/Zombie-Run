using UnityEngine;

namespace ZombieRun.Entities
{
    using Player;
    using Misc;

    public class HealthBehavior : EntityBehavior
    {
        [SerializeField] private Effect _deathEffect = null;

        public override void OnInited()
        {

        }

        public void Die()
        {
            if (_deathEffect)
                CreateEffect(Source.transform);

            Player.Instance.RemoveFromGroup(Source as StackableCharacter);

            Destroy(gameObject);
        }

        private void CreateEffect(Transform transform)
        {
            Instantiate(_deathEffect._prefab, transform.position, transform.rotation);
        }
    }
}