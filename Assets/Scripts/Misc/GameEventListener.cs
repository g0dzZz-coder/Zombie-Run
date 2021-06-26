using UnityEngine;
using UnityEngine.Events;

namespace ZombieRun.Misc
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Response;

        private void OnEnable()
        {
            Event.Register(this);
        }

        private void OnDisable()
        {
            Event.Unregister(this);
        }

        public void RaiseEvent()
        {
            Response.Invoke();
        }
    }
}