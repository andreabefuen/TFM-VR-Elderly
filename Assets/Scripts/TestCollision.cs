using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TestCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<XRDirectInteractor>() != null)
        {
            Debug.Log("Triggered collision with " + collision.gameObject.name);
        }

        Debug.Log("SSAHOOSFJG");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<XRDirectInteractor>() != null)
        {
            Debug.Log("Triggered collision with " + other.name);
        }
        Debug.Log("SSAHOOSSGSFRGGFFJG");

    }
}
