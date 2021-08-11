using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITabletController : MonoBehaviour
{
    UIInfoCanvas[] allInfoCanvas;

    int index = 0;
    int maxCount = 0;
    private void Awake()
    {
        allInfoCanvas = this.gameObject.GetComponentsInChildren<UIInfoCanvas>();
        maxCount = allInfoCanvas.Length;
        //Debug.Log("Count: " + maxCount);

        foreach (var item in allInfoCanvas)
        {
            item.gameObject.SetActive(false);
        }
        allInfoCanvas[index].gameObject.SetActive(true);

    }

    public void NextCanvas()
    {
        allInfoCanvas[index].gameObject.SetActive(false);

        if (index == maxCount-1)
        {
            index = 0;

        }
        else
            index++;
        allInfoCanvas[index].gameObject.SetActive(true);
    }
    public void PreviousCanvas()
    {
        allInfoCanvas[index].gameObject.SetActive(false);
        if (index == 0)
        {
            index = maxCount-1;

        }
        else
            index--;
        allInfoCanvas[index].gameObject.SetActive(true);
    }
}
