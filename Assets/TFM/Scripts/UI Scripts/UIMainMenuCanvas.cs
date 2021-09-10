using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenuCanvas : MonoBehaviour
{

    public void OnStartGameButtonPressed()
    {
        GameManager.Instance.OnStartGameClickButton();
    }
    public void OnExitGamePressed()
    {
        GameManager.Instance.OnExitClickButton();
    }
}
