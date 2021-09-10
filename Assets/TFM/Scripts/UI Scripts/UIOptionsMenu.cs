using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIOptionsMenu : MonoBehaviour
{
    public Slider volumenSlider;

    private void Awake()
    {
        volumenSlider.onValueChanged.AddListener(OnVolumenChange);

    }

    private void OnVolumenChange(float value)
    {
        GameManager.Instance.OnVolumenChange((int)value);
    }

}
