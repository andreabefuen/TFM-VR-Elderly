using Scripts.Tools.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Tools.ScriptableEvents.Listeners
{
    public class BaseGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField] private E gameEvent = null;
        [SerializeField] private UER unityEventResponse = null;

        private void OnEnable()
        {
            if (gameEvent == null) return;

            gameEvent.SubscribeListener(this);
        }
        private void OnDisable()
        {
            if (gameEvent == null) return;

            gameEvent.UnsubscribeListener(this);
        }
 
        public void OnEventRaised(T item)
        {
            if (unityEventResponse == null) return;

            unityEventResponse.Invoke(item);
        }
    }

}
