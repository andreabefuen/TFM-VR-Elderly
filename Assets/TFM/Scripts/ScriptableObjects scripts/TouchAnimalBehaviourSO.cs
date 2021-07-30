using Scripts.Tools.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behaviour/Animal behaviour SO")]
public class TouchAnimalBehaviourSO : TouchBehaviourSO
{
    [Header("Touch variables")]
    public float TouchTime = 1f;
    public ParticleSystem LoveParticle;
    public AudioEvent AnimalSound;

    [Header("Feed variables")]
    public float FeedTime = 1f;
    public ParticleSystem FeedParticle;
    public AudioEvent FeedSound;

    public string animationPetStringTrigger;
    public string animationFeedStringTrigger;
    public StringEvent onPetAnimal;
    public StringEvent onFeedAnimal;

    public override IEnumerator FeedCoroutine(MonoBehaviour obj)
    {
        var transform = obj.transform;
        Vector3 basePosition = transform.position;
        Vector3 baseScale = transform.localScale;

        ParticleSystem particles = null;

        if (FeedParticle)
        {
            particles = Instantiate(LoveParticle);
            particles.transform.position = basePosition;
            particles.transform.rotation = transform.rotation;
        }


        if (FeedSound)
        {
            var audioPlayer = new GameObject("Animal audio", typeof(AudioSource)).GetComponent<AudioSource>();
            audioPlayer.transform.position = basePosition;
            FeedSound.Play(audioPlayer);
            Destroy(audioPlayer.gameObject, audioPlayer.clip.length * audioPlayer.pitch);
        }

        if (particles)
        {
            Destroy(particles.gameObject, particles.main.duration);
        }

        onFeedAnimal?.Raise(animationFeedStringTrigger);

        yield return null;
    }

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

        onPetAnimal?.Raise(animationPetStringTrigger);

        yield return null;
    }

  
}
