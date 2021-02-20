using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrowing : MonoBehaviour
{
    public PlantGrowingBehaviour plantGrowing;
    private void Awake()
    {
        if (plantGrowing) StartCoroutine(plantGrowing.StartGrowing(this));
    }
}
