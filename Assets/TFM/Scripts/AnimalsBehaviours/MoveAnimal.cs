using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAnimal : MonoBehaviour
{
    private AnimalBehaviour animalBehaviour;

    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        animalBehaviour = GetComponent<AnimalBehaviour>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        //StartCoroutine(MoveIfHungry());
        //StartCoroutine(MoveRandomly());
        StartCoroutine(MoveIfHungryNavmesh());
        StartCoroutine(MoveRandomlyNavmesh());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WalkToPlayer()
    {
        if (animalBehaviour) animalBehaviour.WalkToPlayer();

    }
    void WalkTo(Vector3 goal)
    {
        if (animalBehaviour) animalBehaviour.WalkTo(goal);
    }

    void WalkToPlayerAI()
    {
        if (animalBehaviour) animalBehaviour.WalkToPlayerAI();

    }

    void WalkToAI(Vector3 goal)
    {
        if (animalBehaviour) animalBehaviour.WalkToAI(goal);

    }

    IEnumerator MoveIfHungry()
    {
        while (animalBehaviour.animal.GetCurrentValueFeed() == 0)
        {
            Debug.Log("hungry!");
            WalkToPlayer();
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

    IEnumerator MoveIfHungryNavmesh()
    {
        while (animalBehaviour.animal.GetCurrentValueFeed() == 0)
        {
            Debug.Log("hungry!");
            WalkToPlayerAI();
            yield return null;
        }
    }

    IEnumerator MoveRandomlyNavmesh()
    {
        while (true)
        {
            Vector3 aux = new Vector3(Random.insideUnitCircle.x * 10, this.gameObject.transform.position.y, Random.insideUnitCircle.y * 10);
            yield return null;
            WalkToAI(aux);
            yield return new WaitForSeconds(10f);
        }
    }
}
