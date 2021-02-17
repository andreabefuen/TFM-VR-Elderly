using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTimer : MonoBehaviour
{
    public Text showingText;

    public void UpdateTimeText(float duration)
    {
        showingText.text = "Duration: " + duration;
    }
}
