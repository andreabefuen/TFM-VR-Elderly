using System;
using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class MissionsInformationBubble : MonoBehaviour
{
    public GameObject informationBubble;
    public MissionsSO missionSO;

    public Button acceptButton;
    public Button cancelButton;

    private void Awake()
    {
        informationBubble.SetActive(false);
        acceptButton.onClick.AddListener(OnAcceptMissionClicked);
        cancelButton.onClick.AddListener(OnCancelMissionClicked);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            informationBubble.SetActive(true);
        }
    }

    private void OnAcceptMissionClicked()
    {
        Debug.Log("Mission Accepted");
        //Missions missions = FindObjectOfType<Missions>().gameObject.GetComponent<Missions>();
        Missions.Instance.AddToMissions(missionSO, false);
        informationBubble.SetActive(false);

    }

    private void OnCancelMissionClicked()
    {
        informationBubble.SetActive(false);
    }
}
