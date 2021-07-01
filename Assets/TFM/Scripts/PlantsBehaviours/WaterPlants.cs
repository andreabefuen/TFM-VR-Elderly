using Assets.TFM.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlants : CollisionBehaviour
{
    public GrowingBehaviour[] plantToGrow;

    private void Awake()
    {
        plantToGrow = this.GetComponentsInChildren<GrowingBehaviour>();
    }
    public override void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Watering Can"))
        {
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
            foreach (var item in plantToGrow)
            {
               item.StartGrowing();

            }
            Debug.Log("GROW");
        }
    }
}
