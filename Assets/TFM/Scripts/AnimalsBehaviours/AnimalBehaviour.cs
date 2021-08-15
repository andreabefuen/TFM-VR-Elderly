using Scripts.Tools.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    public AnimalInformationSO animal;

    public Transform playerTransform;

    public AnimalBehaviourSO AnimalBehaviourSO;



    public void BePetted(int value)
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.TouchCoroutine(this, value, animal));

    }

    public void BeFeeded(int value)
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.FeedCoroutine(this, value, animal));


    }

    public void WalkTo(Vector3 goal)
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.MovementCoroutine(this, goal));
    }

    public void WalkToPlayer()
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.MovementCoroutine(this, playerTransform));
    }

    public void WalkToPlayerAI()
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.MovementNavmeshCoroutine(this, playerTransform));
    }

    public void WalkToAI(Vector3 goal)
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.MovementNavmeshCoroutine(this, goal));
    }

}
