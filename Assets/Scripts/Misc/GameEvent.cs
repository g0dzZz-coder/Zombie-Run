using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Misc
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Misc/Game Event", order = 51)]
    public class GameEvent : ScriptableObject
    {
        private readonly HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

        public void Invoke()
        {
            foreach (var listener in _listeners)
                listener.RaiseEvent();
        }

        public void Register(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}