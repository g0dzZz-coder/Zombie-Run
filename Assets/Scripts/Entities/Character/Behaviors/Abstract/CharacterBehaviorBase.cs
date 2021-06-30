using UnityEngine;

namespace ZombieRun.Entities.Characters
{
    [RequireComponent(typeof(Character))]
    public abstract class CharacterBehaviorBase : MonoBehaviour
    {
        protected Character Source { get; set; }

        public void Init(Character source)
        {
            Source = source;
            OnInited();
        }

        protected abstract void OnInited();
    }
}