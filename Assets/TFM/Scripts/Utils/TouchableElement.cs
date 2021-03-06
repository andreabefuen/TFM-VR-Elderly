using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchableElement : MonoBehaviour
{
    public float Love = 0;
    public float MaxLove = 100;
    public float LovePerPet = 10;


    public void GivingLove(float love)
    {
        Love += love;

        if(Love > MaxLove) { Love = MaxLove; }

        var animalBehaviour = GetComponent<AnimalBehaviour>();
        if (animalBehaviour) animalBehaviour.BePetted();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GivingLove(LovePerPet);
            Debug.Log("PET");
        }

        //if (other.GetComponent<XRDirectInteractor>() != null)
        //{
        //    GivingLove(LovePerPet);
        //    Debug.Log("PET");
        //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GivingLove(LovePerPet);
            Debug.Log("PET");
        }
        Debug.Log("PET");

    }
}
