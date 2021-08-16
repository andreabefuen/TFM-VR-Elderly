using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleBehaviour : MonoBehaviour
{
    public PeopleBehaviourSO PeopleBehaviourSO;
    public Animator animatorController;

    public void Talk()
    {
        if (PeopleBehaviourSO) StartCoroutine(PeopleBehaviourSO.TalkCoroutine(this));
    }
    public void WalkRandomly(Vector3 goal)
    {
        if (PeopleBehaviourSO) StartCoroutine(PeopleBehaviourSO.MovementCoroutine(this, goal));
    }
}
