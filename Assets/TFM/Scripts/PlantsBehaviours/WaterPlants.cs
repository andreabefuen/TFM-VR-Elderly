using Assets.TFM.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlants : CollisionBehaviour
{
    public GrowingBehaviour[] plantToGrow;
    public int numPlants;
    public PickupItem[] pickableItems;



    private void Awake()
    {
        plantToGrow = this.GetComponentsInChildren<GrowingBehaviour>();
        numPlants = plantToGrow.Length;

        pickableItems = this.GetComponentsInChildren<PickupItem>();

        foreach (var item in pickableItems)
        {
            item.pickedItem += OneLess;
        }
    }

    private void OnDisable()
    {
        foreach (var item in pickableItems)
        {
            item.pickedItem -= OneLess;
        }
    }

    public override void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Watering Can"))
        {
            if(numPlants == 0)
            {
                ResetThisPlant();
            }
            foreach (var item in plantToGrow)
            {
                item.StartGrowing();

            }
            Debug.Log("GROW");
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Watering Can"))
        {
            if (numPlants == 0)
            {
                ResetThisPlant();
            }
            foreach (var item in plantToGrow)
            {
               item.StartGrowing();

            }
            Debug.Log("GROW");
        }
    }
    void OneLess()
    {
        numPlants--;
    }

    public void ResetThisPlant()
    {
        foreach (var item in plantToGrow)
        {
            item.gameObject.SetActive(true);
        }

        numPlants = plantToGrow.Length;
    }
}
