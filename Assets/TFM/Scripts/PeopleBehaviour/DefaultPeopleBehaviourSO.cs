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
    public string animationGreetTrigger;

    public StringEvent onMoveCharacter;

    bool canMove = false;

    public override IEnumerator MovementCoroutine(MonoBehaviour obj, Transform goal)
    {
        yield return new WaitUntil(() => canMove);

        var transform = obj.transform;
        //transform.LookAt(goal);
        NavMeshAgent navMesh = obj.GetComponent<NavMeshAgent>();
        navMesh.SetDestination(goal.position);

        navMesh.isStopped = false;
        onMoveCharacter?.Raise(animationMovementTrigger);
        yield return new WaitUntil(() => navMesh.remainingDistance <= 3);
        onMoveCharacter?.Raise(animationIdleTrigger);
        navMesh.isStopped = true;
    }



    public override IEnumerator MovementCoroutine(MonoBehaviour obj, Vector3 goal)
    {
        Debug.Log("Can move??? " + canMove);
        if (!canMove)
        {
            yield return new WaitUntil(() => canMove == true);

        }
        else
        {
            Debug.Log("SE PUEDE MOVER");

            var transform = obj.transform;
            //transform.LookAt(goal);
            NavMeshAgent navMesh = obj.GetComponent<NavMeshAgent>();
            navMesh.SetDestination(goal);
            if (navMesh.remainingDistance > 3)
            {
                navMesh.isStopped = false;
                onMoveCharacter?.Raise(animationMovementTrigger);
            }
            while (navMesh.remainingDistance > 3)
            {
                yield return null;
            }
            //yield return new WaitUntil(() => navMesh.remainingDistance <= 3);
            Debug.Log("idle");
            navMesh.isStopped = true;
            onMoveCharacter?.Raise(animationIdleTrigger);
            yield return null;
        }
      
        //navMesh.isStopped = false;
        //onMoveCharacter?.Raise(animationMovementTrigger);
        //yield return new WaitUntil(() => navMesh.remainingDistance <= 3);
        //onMoveCharacter?.Raise(animationIdleTrigger);
        //navMesh.isStopped = true;
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

    public override IEnumerator WaitForMissionAcceptance(MonoBehaviour obj)
    {
        MissionsInformationBubble aux = obj.GetComponent<MissionsInformationBubble>();
        canMove = false;
        onMoveCharacter?.Raise(animationGreetTrigger);
        Debug.Log("TRIGGER GREET");

        while (!aux.missionSO.IsAccepted) { yield return null; }
        //yield return new WaitUntil(() => aux.missionSO.IsAccepted == true);
        canMove = true;
        Debug.Log("mission aaceptada");
       

    }
}
