using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInfoCanvas : MonoBehaviour
{
    private void Awake()
    {
        UIInfoCanvas[] allInfoCanvas = this.gameObject.GetComponentsInChildren<UIInfoCanvas>();
    }
}
