using Scripts.Tools.ScriptableEvents.Listeners;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Tools.ScriptableEvents.Events
{
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private readonly List<IGameEventListener<T>> eventListeners = new List<IGameEventListener<T>>();

        public void Raise(T item)
        {
            eventListeners.ForEach(s => s.OnEventRaised(item));
        }

        public void SubscribeListener(IGameEventListener<T> listener)
        {
            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }

        public void UnsubscribeListener(IGameEventListener<T> listener)
        {
            if (eventListeners.Contains(listener))
            {
                eventListeners.Remove(listener);
            }
        }

    }
}
