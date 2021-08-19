using Scripts.Tools.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFM.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Tool/New tool")]
    public class ToolSO : ScriptableObject, ITool
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
        public AudioEvent hitSound;



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

        public void HitSound()
        {
            if (hitSound)
            {
                var audioPlayer = new GameObject("Hit audio", typeof(AudioSource)).GetComponent<AudioSource>();
                //audioPlayer.transform.position = basePosition;
                hitSound.Play(audioPlayer);
                Destroy(audioPlayer.gameObject, audioPlayer.clip.length * audioPlayer.pitch);
            }
        }

        IEnumerator DisplayTool(MonoBehaviour obj)
        {
            yield return null;
        }
    }

}