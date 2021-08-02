using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimal : MonoBehaviour
{
    private AnimalBehaviour animalBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        animalBehaviour = GetComponent<AnimalBehaviour>();
        StartCoroutine(MoveIfHungry());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Walk()
    {
        if (animalBehaviour) animalBehaviour.Walk();

    }

    IEnumerator MoveIfHungry()
    {
        Debug.Log("Wait until hungry");
        yield return new WaitUntil(() => animalBehaviour.animal.GetCurrentValueFeed() == 0);
        Debug.Log("hungry!");
        Walk();

    }
}
