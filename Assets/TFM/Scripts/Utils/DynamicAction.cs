using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace TFM.Utils
{
    public abstract class DynamicAction<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [SerializeField, Multiline] private string description;
#endif

        public abstract UnityAction Action(T i, int n, object extra = null);
    }

    public abstract class ItemAction : DynamicAction<ItemSO>
    {
        public override abstract UnityAction Action(ItemSO i, int n, object extra = null);
    }


}



