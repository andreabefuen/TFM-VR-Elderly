using Assets.TFM.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedAnimal : CollisionBehaviour
{
    public string nameTagToCompare;

    public void FeedAnimalBehaviour()
    {
        //Love += love;
        //
        //if (Love > MaxLove) { Love = MaxLove; }
        //
        var animalBehaviour = GetComponent<AnimalBehaviour>();
        if (animalBehaviour) animalBehaviour.BeFeeded();
    }

    public override void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag(nameTagToCompare))
        {
            FeedAnimalBehaviour();
            Debug.Log("FEED");
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(nameTagToCompare))
        {
            FeedAnimalBehaviour();
            Debug.Log("FEED");
        }
    }
}
