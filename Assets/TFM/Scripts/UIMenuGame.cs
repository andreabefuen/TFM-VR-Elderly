using Scripts.Tools.ScriptableEvents.UnityEvents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UIMenuGame : MonoBehaviour
{
    public GameObject menuCanvasObject;

    public MenuButtonWatcher menuButtonWatcher;

    bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        menuCanvasObject.SetActive(false);

        menuButtonWatcher.menuButtonPressed.AddListener(OnMenuButtonPressed);
    }

    public void OnMenuButtonPressed(bool pressed)
    {
        isPressed = !isPressed;
        menuCanvasObject.SetActive(isPressed);
    }

}
