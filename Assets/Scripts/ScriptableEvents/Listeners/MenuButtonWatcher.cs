using Scripts.Tools.ScriptableEvents.UnityEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MenuButtonWatcher : MonoBehaviour
{
    public MenuButtonEvent menuButtonPressed;
    private bool lastButtonState = false;
    private List<InputDevice> devicesWithMenuButton;

    private void Awake()
    {
        if (menuButtonPressed == null)
        {
            menuButtonPressed = new MenuButtonEvent();
        }

        devicesWithMenuButton = new List<InputDevice>();
    }

    private void OnEnable()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (InputDevice device in allDevices)
            InputDevices_deviceConnected(device);

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }
    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithMenuButton.Clear();
    }
    private void InputDevices_deviceConnected(InputDevice device)
    {
        bool discardedValue;
        if (device.TryGetFeatureValue(CommonUsages.menuButton, out discardedValue))
        {
            devicesWithMenuButton.Add(device); // Add any devices that have a primary button.
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (devicesWithMenuButton.Contains(device))
            devicesWithMenuButton.Remove(device);
    }
    void Update()
    {
        bool tempState = false;
        foreach (var device in devicesWithMenuButton)
        {
            bool menuButtonState = false;
            tempState = device.TryGetFeatureValue(CommonUsages.menuButton, out menuButtonState) // did get a value
                        && menuButtonState // the value we got
                        || tempState; // cumulative result from other controllers
        }

        if (tempState != lastButtonState) // Button state changed since last frame
        {
            menuButtonPressed.Invoke(tempState);
            lastButtonState = tempState;
        }
    }
}

