using Scripts.Tools.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tool/New tool")]
public class ToolSO :  ScriptableObject, ITool
{
    public string toolName;
    public string ToolName => toolName;

    public string toolDescription;
    public string ToolDescription => toolDescription;

    public GameObject toolPrefab;
    public GameObject ToolPrefab => toolPrefab;

    public VoidEvent onGrabTool;
    public VoidEvent onReleaseTool;

    public ParticleSystem particles;

    public void GrabbingTool()
    {
        Debug.LogError("Grabbing " + toolName);
        onGrabTool?.Raise();
    }

    public void ReleaseTool()
    {
        Debug.LogError("Release " + toolName);
        onReleaseTool?.Raise();
    }

    IEnumerator DisplayTool(MonoBehaviour obj)
    {
        yield return null;
    }
}
