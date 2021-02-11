using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Tools.ScriptableEvents.Listeners
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T item);
    }
}
