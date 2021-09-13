using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCharacter : MonoBehaviour
{
    private PeopleBehaviour peopleBehaviour;

    Coroutine moveCoroutine = null;
    // Start is called before the first frame update
    void Start()
    {
        peopleBehaviour = GetComponent<PeopleBehaviour>();
        //StartCoroutine(MoveIfHungry());
        moveCoroutine =  StartCoroutine(MoveRandomly());
        

    }

    IEnumerator MoveRandomly()
    {

            Vector3 aux = new Vector3(Random.insideUnitCircle.x * 20, this.gameObject.transform.position.y, Random.insideUnitCircle.y * 20);
            MoveRandomly(aux);
            yield return new WaitForSeconds(10f);
            StopCoroutine(moveCoroutine);
            moveCoroutine = StartCoroutine(MoveRandomly());
            
            
        
    }

    void MoveRandomly(Vector3 goal)
    {
        if (peopleBehaviour) peopleBehaviour.WalkRandomly(goal);

    }
}
