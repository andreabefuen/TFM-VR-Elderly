using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingBehaviour : MonoBehaviour
{
    public PlantGrowingBehaviour plantGrowing;
    [Range(1, 5)]
    public int stages = 3;

    int currentStage = 0;

    private void Awake()
    {
        InvokeRepeating("StartGrowing", 2, stages);
        //StartGrowing();
    }
    public void StartGrowing()
    {
        if (plantGrowing && currentStage < stages)
        {
            //plantGrowing.GrowingTime /= stages;
            StartCoroutine(plantGrowing.StartGrowingStage(this,stages));
            currentStage++;
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
