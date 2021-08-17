using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PeopleBehaviourSO : ScriptableObject
{
    public abstract IEnumerator MovementCoroutine(MonoBehaviour obj, Transform goal);

    public abstract IEnumerator MovementCoroutine(MonoBehaviour obj, Vector3 goal);
    public abstract IEnumerator TalkCoroutine(MonoBehaviour obj);

    public abstract IEnumerator WaitForMissionAcceptance(MonoBehaviour obj);
}
