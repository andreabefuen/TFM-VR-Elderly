using Scripts.Tools.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{

    public StringEvent onPetAnimal;
    public TouchBehaviourSO TouchBehaviour;

    public string animationStringTrigger;

    public void BePetted()
    {
        if (TouchBehaviour) StartCoroutine(TouchBehaviour.TouchCoroutine(this));
        onPetAnimal?.Raise(animationStringTrigger);
    }
}
