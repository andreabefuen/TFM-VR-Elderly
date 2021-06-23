using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Growing Behaviour/Plant growing behaviour")]
public class PlantGrowingBehaviour : GrowingBehaviourSO
{
    public float GrowingTime = 1f;
    public float MovementScale = 0.2f;
    public bool MoveInsteadOfScale = false;
    public ParticleSystem GrowingParticle;
    public float GrowingSurroundFactor = 1.3f;

    public AudioEvent GrowingAudio;

    int currentStage = 1;
    public override IEnumerator StartGrowing(MonoBehaviour obj)
    {
        var transform = obj.transform;

        Vector3 basePosition = transform.position;
        Vector3 baseScale = transform.localScale;
        
        Vector3 startingScale = Vector3.zero;

        var localBounds = obj.GetComponentInChildren<MeshFilter>().sharedMesh.bounds;

        ParticleSystem particles = null;

        if (GrowingParticle)
        {
            particles = Instantiate(GrowingParticle);
            particles.transform.position = basePosition;
            particles.transform.rotation = transform.rotation;

            var shapeModule = particles.shape;
            shapeModule.scale = new Vector3(localBounds.size.x, 0, localBounds.size.z) * GrowingSurroundFactor;
        }

        if (GrowingAudio)
        {
            var audioPlayer = new GameObject("Growing audio", typeof(AudioSource)).GetComponent<AudioSource>();
            audioPlayer.transform.position = basePosition;
            GrowingAudio.Play(audioPlayer);
            Destroy(audioPlayer.gameObject, audioPlayer.clip.length * audioPlayer.pitch);
        }
        float startTime = Time.time;

        while (Time.time < startTime + GrowingTime)
        {
            float progress = Mathf.Clamp01((Time.time - startTime) / GrowingTime);

            if (MoveInsteadOfScale)
            {
                transform.position = basePosition + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * MovementScale +
                                     Vector3.up * progress * localBounds.size.y;
            }
            else
            {
                transform.localScale = new Vector3(Mathf.Lerp(startingScale.x, baseScale.x, progress), Mathf.Lerp(startingScale.y, baseScale.y, progress), baseScale.z);
                transform.position = basePosition + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * MovementScale;
            }
            yield return null;


        }
        
        if (particles)
        {
            var emission = particles.emission;
            emission.enabled = false;

            Destroy(particles.gameObject, particles.main.duration);
        }

    }

    public override IEnumerator StartGrowingStage(MonoBehaviour obj, int numStages)
    {
        //if(currentStage > numStages) { yield return null; }
        var transform = obj.transform;

        Vector3 basePosition = transform.position;
        Vector3 baseScale = transform.localScale;

        Vector3 startingScale = Vector3.zero;

        var localBounds = obj.GetComponentInChildren<MeshFilter>().sharedMesh.bounds;

        ParticleSystem particles = null;

        if (GrowingParticle)
        {
            particles = Instantiate(GrowingParticle);
            particles.transform.position = basePosition;
            particles.transform.rotation = transform.rotation;

            var shapeModule = particles.shape;
            shapeModule.scale = new Vector3(localBounds.size.x, 0, localBounds.size.z) * GrowingSurroundFactor;
        }

        if (GrowingAudio)
        {
            var audioPlayer = new GameObject("Growing audio", typeof(AudioSource)).GetComponent<AudioSource>();
            audioPlayer.transform.position = basePosition;
            GrowingAudio.Play(audioPlayer);
            Destroy(audioPlayer.gameObject, audioPlayer.clip.length * audioPlayer.pitch);
        }
        float startTime = Time.time;

        float timeStages = GrowingTime * numStages;

        while (Time.time < startTime + GrowingTime)
        {
            float progress = Mathf.Clamp01((Time.time - startTime) / timeStages);

            if (MoveInsteadOfScale)
            {
                transform.position = basePosition + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * MovementScale +
                                     Vector3.up * progress * localBounds.size.y;
            }
            else
            {
                transform.localScale = new Vector3(Mathf.Lerp(startingScale.x, baseScale.x, progress), Mathf.Lerp(startingScale.y, baseScale.y, progress), baseScale.z);
                transform.position = basePosition + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * MovementScale;
            }
            yield return null;
            currentStage++;


        }

        if (particles)
        {
            var emission = particles.emission;
            emission.enabled = false;

            Destroy(particles.gameObject, particles.main.duration);
        }

    }
}
