using UnityEngine;

namespace ZombieRun.Entities.Characters
{
    [RequireComponent(typeof(Character))]
    public abstract class CharacterBehaviorBase : MonoBehaviour
    {
        protected Character Source { get; set; }
        protected bool IsInited { get; set; }

        public void Init(Character source)
        {
            Source = source;
            OnInited();

            IsInited = true;
        }

        protected abstract void OnInited();
    }
}