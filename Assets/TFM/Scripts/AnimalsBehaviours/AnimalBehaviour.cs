using Scripts.Tools.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{


    public TouchAnimalBehaviourSO AnimalBehaviourSO;



    public void BePetted()
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.TouchCoroutine(this));

    }

    public void BeFeeded()
    {
        if (AnimalBehaviourSO) StartCoroutine(AnimalBehaviourSO.FeedCoroutine(this));


    }
}
