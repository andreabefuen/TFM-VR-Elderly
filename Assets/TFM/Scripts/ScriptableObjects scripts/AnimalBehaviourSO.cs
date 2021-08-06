using System.Collections;
using UnityEngine;

public abstract class AnimalBehaviourSO : ScriptableObject
{
    public abstract IEnumerator TouchCoroutine(MonoBehaviour obj, int value, AnimalInformationSO animal);

    public abstract IEnumerator FeedCoroutine(MonoBehaviour obj, int value, AnimalInformationSO animal);

    public abstract IEnumerator MovementCoroutine(MonoBehaviour obj, Vector3 goal);

    public abstract IEnumerator MovementCoroutine(MonoBehaviour obj, Transform goal);
}
