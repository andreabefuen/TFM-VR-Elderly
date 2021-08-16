using Scripts.Tools.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Behaviour/Default person behaviour SO")]

public class DefaultPeopleBehaviourSO : PeopleBehaviourSO
{
    public SimpleAudioEvent personTalkingAudio;

    public string animationMovementTrigger;
    public string animationIdleTrigger;

    public StringEvent onMoveCharacter;

    public override IEnumerator MovementCoroutine(MonoBehaviour obj, Transform goal)
    {
        var transform = obj.transform;
        //transform.LookAt(goal);
        NavMeshAgent navMesh = obj.GetComponent<NavMeshAgent>();
        navMesh.SetDestination(goal.position);

        if (navMesh.remainingDistance <= 3)
        {
            onMoveCharacter?.Raise(animationIdleTrigger);
            navMesh.isStopped = true;
            yield return null;
        }
        else
        {
            navMesh.isStopped = false;

            Debug.Log("hofjdahsgjldsag");
            onMoveCharacter?.Raise(animationMovementTrigger);

            while (navMesh.remainingDistance > 3)
            {
                //transform.LookAt(Vector3.forward *-1);
                yield return null;
                onMoveCharacter?.Raise(animationIdleTrigger);
                navMesh.isStopped = true;
            }

            //yield return new WaitUntil(() => navMesh.remainingDistance < 1);

        }
    }



    public override IEnumerator MovementCoroutine(MonoBehaviour obj, Vector3 goal)
    {
        var transform = obj.transform;
        //transform.LookAt(goal);
        NavMeshAgent navMesh = obj.GetComponent<NavMeshAgent>();
        navMesh.SetDestination(goal);
        navMesh.isStopped = false;
        onMoveCharacter?.Raise(animationMovementTrigger);

        Debug.Log("adfhasdjg");
        while(navMesh.remainingDistance >= 3)
        {
            yield return new WaitUntil(() => navMesh.remainingDistance < 3);
        }
        if(navMesh.remainingDistance< 3)
        {
            onMoveCharacter?.Raise(animationIdleTrigger);
            navMesh.isStopped = true;
        }
        //
        // if (navMesh.remainingDistance < 2)
        // {
        //     onMoveCharacter?.Raise(animationIdleTrigger);
        //     navMesh.isStopped = true;
        //     yield return null;
        // }
        // else
        // {
        //     navMesh.isStopped = false;
        //
        //     Debug.Log("Movimiento");
        //     onMoveCharacter?.Raise(animationMovementTrigger);
        //
        //     while (navMesh.remainingDistance >= 2)
        //     {
        //         //transform.LookAt(Vector3.forward *-1);
        //         yield return null;
        //       
        //
        //     }
        //     onMoveCharacter?.Raise(animationIdleTrigger);
        //     navMesh.isStopped = true;
        //
        //
        //     //yield return new WaitUntil(() => navMesh.remainingDistance < 1);
        //
        // }
    }

    public override IEnumerator TalkCoroutine(MonoBehaviour obj)
    {
        var transform = obj.transform;

        Vector3 basePosition = transform.position;
        if (personTalkingAudio)
        {
            var audioPlayer = new GameObject("Person audio", typeof(AudioSource)).GetComponent<AudioSource>();
            audioPlayer.transform.position = basePosition;
            personTalkingAudio.Play(audioPlayer);
            Destroy(audioPlayer.gameObject, audioPlayer.clip.length * audioPlayer.pitch);
        }

        yield return null;
    }
}
