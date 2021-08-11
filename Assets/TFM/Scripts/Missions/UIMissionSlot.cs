using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIMissionSlot : MonoBehaviour
{
    [SerializeField] private Button finishTaskButton = null;
    [SerializeField] private TextMeshProUGUI missionNameText = null;
    [SerializeField] private TextMeshProUGUI missionDescriptionText = null;
    [SerializeField] private Image iconMission = null;
    [SerializeField] private TextMeshProUGUI countText = null;


    public delegate void OnClickFinishMission();
    public OnClickFinishMission onClickFinishMission;


    public virtual void UpdateSlotUI(MissionsSO mission)
    {
        Debug.Log("NO SE LLAMA");
        missionNameText.text = mission.MissionName;
        missionDescriptionText.text = mission.Description;

        iconMission.sprite = mission.Icon;
        countText.text = mission.Cuantity.ToString();
    }

    private void Start()
    {
        if(finishTaskButton != null)
        {
            finishTaskButton.onClick.AddListener(() => onClickFinishMission?.Invoke());
        }
    }


}
