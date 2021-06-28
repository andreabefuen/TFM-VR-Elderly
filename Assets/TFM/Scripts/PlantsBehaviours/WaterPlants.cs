using Assets.TFM.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlants : CollisionBehaviour
{
    public GrowingBehaviour plantToGrow;
    public override void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Watering Can"))
        {
            
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Watering Can"))
        {
            plantToGrow.StartGrowing();
            Debug.Log("GROW");
        }
    }
}
