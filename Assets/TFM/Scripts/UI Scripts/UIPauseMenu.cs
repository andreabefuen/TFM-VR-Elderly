using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseMenu : MonoBehaviour
{
    public GameObject menuCanvasObject;

    public MenuButtonWatcher menuButtonWatcher;

    bool isPressed = false;

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

    public void OnPrincipalMenuPressed()
    {
        GameManager.Instance.OnPrincipalMenuButtonClicked();
    }

    public void OnExitButtonClicked()
    {
        GameManager.Instance.OnExitClickButton();
    }

    public void OnResetToolClicked()
    {
        GameObject.Find("ToolBench")?.GetComponent<ToolSpawner>().InstantiateAllTools();
    }
}
