using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Touchable/Animal Touch SO")]
public class TouchAnimalBehaviour : TouchBehaviourSO
{
    public float TouchTime = 1f;
    public ParticleSystem LoveParticle;
    public AudioEvent AnimalSound;

    public override IEnumerator TouchCoroutine(MonoBehaviour obj)
    {
        var transform = obj.transform;
        Vector3 basePosition = transform.position;
        Vector3 baseScale = transform.localScale;

        ParticleSystem particles = null;

        if (LoveParticle)
        {
            particles = Instantiate(LoveParticle);
            particles.transform.position = basePosition;
            particles.transform.rotation = transform.rotation;
        }


        if (AnimalSound)
        {
            var audioPlayer = new GameObject("Animal audio", typeof(AudioSource)).GetComponent<AudioSource>();
            audioPlayer.transform.position = basePosition;
            AnimalSound.Play(audioPlayer);
            Destroy(audioPlayer.gameObject, audioPlayer.clip.length * audioPlayer.pitch);
        }

        if (particles)
        {
            Destroy(particles.gameObject, particles.main.duration);
        }

        yield return null;
    }

  
}
