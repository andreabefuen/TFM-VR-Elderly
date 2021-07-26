using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using UnityEngine;

public class ToolBehaviour : MonoBehaviour
{
    public ToolSO tool;

    public void Grab()
    {
        tool.GrabbingTool();
    }
    public void Release()
    {
        tool.ReleaseTool();
    }
}
