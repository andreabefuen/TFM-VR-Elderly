using Assets.TFM.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PetAnimal : CollisionBehaviour
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
