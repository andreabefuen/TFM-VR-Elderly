using Scripts.Tools.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    public AnimalInformationSO animal;

    public Transform playerTransform;

    public AnimalBehaviourSO AnimalBehaviourSO;



    public void BePetted()
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.TouchCoroutine(this));

    }

    public void BeFeeded(int value)
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.FeedCoroutine(this, value, animal));


    }

    public void WalkTo(Transform goal)
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.MovementCoroutine(this, goal));
    }

    public void Walk()
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.MovementCoroutine(this, playerTransform));
    }
}
