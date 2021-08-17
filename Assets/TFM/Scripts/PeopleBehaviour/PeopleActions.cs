using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleActions : MonoBehaviour
{
    private PeopleBehaviour peopleBehaviour;

    private void Start()
    {
        peopleBehaviour = GetComponent<PeopleBehaviour>();

        WaitForMissionAcceptance();
    }

    void WaitForMissionAcceptance()
    {
        if(peopleBehaviour) peopleBehaviour.WaitForAcceptMission();
    }
}
