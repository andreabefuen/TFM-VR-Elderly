using System.Collections;
using UnityEngine;

public abstract class TouchBehaviourSO : ScriptableObject
{
    public abstract IEnumerator TouchCoroutine(MonoBehaviour obj);

    public abstract IEnumerator FeedCoroutine(MonoBehaviour obj);
}
