using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameManager : MonoBehaviour
{

    public AudioClip generalAudio;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayGeneralAudio();
    }

    public void ChangeVolumen(int volumenValue)
    {
        audioSource.volume = volumenValue / 10;
    }


    public void PlayGeneralAudio()
    {
        audioSource.clip = generalAudio;
        audioSource.loop = true;

        audioSource.Play();
    }
}
