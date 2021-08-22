using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSpawner : MonoBehaviour
{
    public List<GameObject> toolsList;
    public List<Transform> pointsToInstantiate;

    List<GameObject> currentTools;

    int index = 0;

    private void Awake()
    {
        currentTools = new List<GameObject>();
        InstantiateAllTools();
    }
    public void InstantiateAllTools()
    {
        DestroyAllTools();
        foreach (var item in toolsList)
        {
            currentTools.Add(Instantiate(item, pointsToInstantiate[index].position, pointsToInstantiate[index].rotation));
            index++;
        }

        index = 0;
    }

    void DestroyAllTools()
    {
        if(currentTools.Count != 0)
        {
            foreach (var item in currentTools)
            {
                Destroy(item);
            }
        }

        currentTools.Clear();
    }
}
