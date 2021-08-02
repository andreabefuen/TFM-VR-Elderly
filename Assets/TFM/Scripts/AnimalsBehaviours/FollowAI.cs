using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{

    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private float movementSpeed = 1.5f;
    [SerializeField] private float maxDistance = 4f;
    [SerializeField] private float minDistance = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform);
        if (Vector3.Distance(transform.position, playerTransform.position) >= minDistance)
        {

            transform.position += transform.forward * movementSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, playerTransform.position) <= maxDistance)
            {
                //Here Call any function U want Like Shoot at here or something
            }
        }
    }
}
