using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameManager : MonoBehaviour
{

    public AudioClip generalAudio;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayGeneralAudio();
    }

    public void ChangeVolumen(float volumenValue)
    {
        audioSource.volume = volumenValue / 10;
    }


    public void PlayGeneralAudio()
    {
        if (audioSource.clip == generalAudio) return;
        audioSource.clip = generalAudio;
        audioSource.loop = true;

        audioSource.Play();
    }
}
