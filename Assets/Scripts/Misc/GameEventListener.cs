using UnityEngine;
using UnityEngine.Events;

namespace ZombieRun.Misc
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _event;
        [SerializeField] private UnityEvent _response;

        private void OnEnable()
        {
            _event.Register(this);
        }

        private void OnDisable()
        {
            _event.Unregister(this);
        }

        public void RaiseEvent()
        {
            _response.Invoke();
        }
    }
}