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
        StartCoroutine(MoveRandomly());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Walk()
    {
        if (animalBehaviour) animalBehaviour.Walk();

    }
    void WalkTo(Vector3 goal)
    {
        if (animalBehaviour) animalBehaviour.WalkTo(goal);
    }

    IEnumerator MoveIfHungry()
    {
        while (animalBehaviour.animal.GetCurrentValueFeed() == 0)
        {
            Debug.Log("hungry!");
            Walk();
            yield return null;
        }
    }

    IEnumerator MoveRandomly()
    {
        while (true)
        {
            Vector3 aux = new Vector3(Random.insideUnitCircle.x * 10, this.gameObject.transform.position.y, Random.insideUnitCircle.y * 10);
            yield return null;
            WalkTo(aux);
            yield return new WaitForSeconds(10f);
        }
       
    }
}
