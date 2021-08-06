using Assets.TFM.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PetAnimal : CollisionBehaviour
{
    public int LovePerPet = 1;


    public void GivingLove(int love)
    {

        var animalBehaviour = GetComponent<AnimalBehaviour>();
        if (animalBehaviour) animalBehaviour.BePetted(love);
    }

    public override void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GivingLove(LovePerPet);
            Debug.Log("PET");
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GivingLove(LovePerPet);
            Debug.Log("PET");
        }
    }
}
