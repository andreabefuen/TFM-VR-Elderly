using Scripts.Tools.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behaviour/Default animal behaviour SO")]
public class DefaultAnimalBehaviourSO : AnimalBehaviourSO
{

    [Header("Touch variables")]
    public float TouchTime = 1f;
    public ParticleSystem LoveParticle;
    public AudioEvent AnimalSound;

    [Header("Feed variables")]
    public float FeedTime = 1f;
    public ParticleSystem FeedParticle;
    public AudioEvent FeedSound;

    [Header("Movement variables")]
    public float Speed = 2f;
    public float maxDistance = 4f;
    public float minDistance = 3f;

    [Header("Animation strings")]
    public string animationPetStringTrigger;
    public string animationFeedStringTrigger;
    public string animationMovementStringTrigger;
    public string animationStopStringTrigger;
    
    [Header("Events")]
    public StringEvent onPetAnimal;
    public StringEvent onFeedAnimal;
    public StringEvent onMoveAnimal;


    public override IEnumerator FeedCoroutine(MonoBehaviour obj, int value, AnimalInformationSO animal)
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
        animal.FeedAnimal(value);

        yield return null;

    }

    public override IEnumerator MovementCoroutine(MonoBehaviour obj, Vector3 goalTransform)
    {
        var transform = obj.transform;
        transform.LookAt(goalTransform);
        onMoveAnimal?.Raise(animationMovementStringTrigger);


        while (Vector3.Distance(transform.position, goalTransform) >= minDistance)
        {
            transform.LookAt(goalTransform);
            transform.position += transform.forward * Speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, goalTransform) <= maxDistance)
            {
                onMoveAnimal?.Raise(animationStopStringTrigger);
                break;

            }
            yield return null;

        }


        
    }

    public override IEnumerator MovementCoroutine(MonoBehaviour obj, Transform goalTransform)
    {
        var transform = obj.transform;
        transform.LookAt(goalTransform.position);
        onMoveAnimal?.Raise(animationMovementStringTrigger);


        while (Vector3.Distance(transform.position, goalTransform.position) >= minDistance)
        {
            transform.LookAt(goalTransform);
            transform.position += transform.forward * Speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, goalTransform.position) <= maxDistance)
            {
                onMoveAnimal?.Raise(animationStopStringTrigger);
                break;

            }
            yield return null;

        }

    }

    public override IEnumerator TouchCoroutine(MonoBehaviour obj, int value, AnimalInformationSO animal)
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
        animal.PetAnimal(value);
    }

}
