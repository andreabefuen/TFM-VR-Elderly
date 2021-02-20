using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GrowingBehaviourSO : ScriptableObject
{
    public abstract IEnumerator StartGrowing(MonoBehaviour obj);
}
