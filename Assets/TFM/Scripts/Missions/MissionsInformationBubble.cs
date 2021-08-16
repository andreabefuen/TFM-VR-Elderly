using System;
using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionsInformationBubble : MonoBehaviour
{
    public GameObject informationBubble;
    public Image iconMission;
    public TextMeshProUGUI cuantityText;
    public MissionsSO missionSO;

    public Button acceptButton;
    public Button cancelButton;

    private void Awake()
    {
        informationBubble.SetActive(false);
        acceptButton.onClick.AddListener(OnAcceptMissionClicked);
        cancelButton.onClick.AddListener(OnCancelMissionClicked);

        InitializeMissionBubble();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            informationBubble.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            informationBubble.SetActive(false);
        }
    }

    void InitializeMissionBubble()
    {
        iconMission.sprite = missionSO.Icon;
        cuantityText.text = "x" + missionSO.Cuantity;
    }

    private void OnAcceptMissionClicked()
    {
        Debug.Log("Mission Accepted");
        //Missions missions = FindObjectOfType<Missions>().gameObject.GetComponent<Missions>();
        Missions.Instance.AddToMissions(missionSO, false);
        //informationBubble.SetActive(false);
        Destroy(this.gameObject);

    }

    private void OnCancelMissionClicked()
    {
        informationBubble.SetActive(false);
    }
}
