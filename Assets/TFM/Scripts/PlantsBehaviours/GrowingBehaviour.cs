﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingBehaviour : MonoBehaviour
{
    public PlantGrowingBehaviourSO plantGrowing;
    [Range(1, 5)]
    public int stages = 3;

    int currentStage = 0;

    Coroutine plantCoroutine;

    private void Awake()
    {
        //InvokeRepeating("StartGrowing", 10, stages);
        //StartGrowing();
    }
    public bool StartGrowing()
    {
        if(currentStage < stages)
        {
            if (plantCoroutine == null)
            {
                StartCoroutine(GrowingCoroutine());

            }
            return false;
        }
        else
        {
            return true;
        }
   
        
    }

    IEnumerator GrowingCoroutine()
    {
        if (plantGrowing && currentStage < stages)
        {
            //plantGrowing.GrowingTime /= stages;
            plantCoroutine = StartCoroutine(plantGrowing.StartGrowingStage(this, stages));
            yield return plantCoroutine;
            currentStage++;
            plantCoroutine = null;
        }
        else
        {
            Debug.Log("YA ha crecido del todo");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
