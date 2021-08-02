using Assets.TFM.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedAnimal : CollisionBehaviour
{
    public string nameTagToCompare;


    public void FeedAnimalBehaviour(int currentValue)
    {
        //Love += love;
        //
        //if (Love > MaxLove) { Love = MaxLove; }
        //
        var animalBehaviour = GetComponent<AnimalBehaviour>();
        if (animalBehaviour) animalBehaviour.BeFeeded(currentValue);
    }

    public override void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag(nameTagToCompare))
        {
            var foodInfo = collider.gameObject.GetComponent<FoodInfo>();
            FeedAnimalBehaviour(foodInfo != null ? foodInfo.foodValue : 1);
            Debug.Log("FEED");
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(nameTagToCompare))
        {
            var foodInfo = other.gameObject.GetComponent<FoodInfo>();
            FeedAnimalBehaviour(foodInfo != null ? foodInfo.foodValue : 1);
            Debug.Log("FEED");
        }
    }
}
