using Assets.TFM.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlants : CollisionBehaviour
{
    public Crops crop;
    public int minutesPassed = 10;
    [Range(0,59)]
    public int secondsPassed = 30;
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
            item.canBePicked = false;
        }
    }

    private void OnDisable()
    {
        foreach (var item in pickableItems)
        {
            item.pickedItem -= OneLess;
        }
        GameFlowManager.Instance.SaveCurrentTimeCrop(crop);
    }

    void ItemsCanBePicked()
    {
        foreach (var item in pickableItems)
        {
            item.canBePicked = true;
        }
    }

    public override void OnCollisionEnter(Collision collider)
    {
        if (!GetIfPossibleWatering())
        {
            Debug.LogError("Not enough time"); return;
        }

        if (collider.gameObject.CompareTag("Watering Can"))
        {
            pickableItems = this.GetComponentsInChildren<PickupItem>();
            numPlants = pickableItems.Length;

            if (numPlants == 0)
            {
                ResetThisPlant();
            }
            foreach (var item in plantToGrow)
            {
                if (item.StartGrowing()) ItemsCanBePicked();

            }
            Debug.Log("GROW");
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (!GetIfPossibleWatering()) { Debug.LogError("Not enough time"); return; }
            
        if (other.CompareTag("Watering Can"))
        {
            if (numPlants == 0)
            {
                ResetThisPlant();
            }
            foreach (var item in plantToGrow)
            {
                if (item.StartGrowing()) ItemsCanBePicked();
               //item.StartGrowing();

            }
            Debug.Log("GROW");
            GameFlowManager.Instance.SaveCurrentTimeCrop(crop);
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

    bool GetIfPossibleWatering()
    {
        minutesPassed += (int) secondsPassed / 60;
        return GameFlowManager.Instance.MinutesIntPassedCrop(crop) >= minutesPassed ? true : false;
        //return GameFlowManager.Instance.SecondsPassedCrop(crop) >= secondsPassed ? true : false;

    }
}
