using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITool 
{
    string ToolName { get; }
    string ToolDescription { get; }

    GameObject ToolPrefab { get; }

    void GrabbingTool();
    void ReleaseTool();
}
