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
    public GameObject textParticlePrefab;
    public Image iconMission;
    public TextMeshProUGUI cuantityText;
    public MissionsSO missionSO;

    public Button acceptButton;
    public Button cancelButton;

    private ParticleSystem textParticle;

    private void Awake()
    {
        if (missionSO.IsAccepted)
        {
            Destroy(this);
            return;
        }
        informationBubble.SetActive(false);
        textParticlePrefab.SetActive(true);
        acceptButton.onClick.AddListener(OnAcceptMissionClicked);
        cancelButton.onClick.AddListener(OnCancelMissionClicked);

        textParticle = textParticlePrefab.GetComponent<ParticleSystem>();
        

        InitializeMissionBubble();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            informationBubble.SetActive(true);
            textParticlePrefab.SetActive(false);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            informationBubble.SetActive(false);
            textParticlePrefab.SetActive(true);

        }
    }

    void InitializeMissionBubble()
    {
        iconMission.sprite = missionSO.Icon;
        cuantityText.text = "x" + missionSO.Cuantity;

        textParticle.Play();
    }

    private void OnAcceptMissionClicked()
    {
        Debug.Log("Mission Accepted");
        //Missions missions = FindObjectOfType<Missions>().gameObject.GetComponent<Missions>();
        Missions.Instance.AddToMissions(missionSO, false);
        //informationBubble.SetActive(false);
        Destroy(informationBubble);
        //Destroy(informationBubble);
        Destroy(this);

    }

    private void OnCancelMissionClicked()
    {
        informationBubble.SetActive(false);
    }
}
