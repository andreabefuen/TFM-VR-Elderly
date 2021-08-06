using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITabletController : MonoBehaviour
{
    UIInfoCanvas[] allInfoCanvas;

    int count = 0;
    int maxCount = 0;
    private void Awake()
    {
        allInfoCanvas = this.gameObject.GetComponentsInChildren<UIInfoCanvas>();
        maxCount = allInfoCanvas.Length;

    }

    public void NextCanvas()
    {
        if (count >= maxCount)
        {
            count = 0;

        }
        allInfoCanvas[count].gameObject.SetActive(false);
        count++;
        allInfoCanvas[count].gameObject.SetActive(true);
    }
    public void PreviousCanvas()
    {
        if (count < 0)
        {
            count = maxCount -1;

        }
        allInfoCanvas[count].gameObject.SetActive(false);
        count--;
        allInfoCanvas[count].gameObject.SetActive(true);
    }
}
