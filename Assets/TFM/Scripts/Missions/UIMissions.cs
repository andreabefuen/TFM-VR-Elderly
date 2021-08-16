using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using UnityEngine;

public class UIMissions : UISlotHolderMissions<MissionsSO>
{
    [SerializeField] private Missions missions = null;

    private void Start()
    {
        //missions = Missions.Instance;
        if(missions)
            InitializeUI(missions.GetMissions, 5);
    }

    protected override void InitializeUI(Dictionary<MissionsSO, string> missions, int numSlots)
    {
        base.InitializeUI(missions, numSlots);
        this.missions.onMissionStateChange += UpdateMissionSlot;
        
    }
    protected override void UpdateSlotAt(int _index, MissionsSO missionType, string state)
    {
        Debug.Log("Se llama??");
        //Si ya ha sido completada, no mostrarla
        missionsSlots[_index].UpdateSlotUI(missionType);

        if (ExtensionMethods.StringToBool(state))
        {
            
            missionsSlots[_index].gameObject.SetActive(false);
            Debug.Log("state");


        }
        else
        {
            missionsSlots[_index].onClickFinishMission += () => MarkAsCompleted(missionType);
            missionsSlots[_index].gameObject.SetActive(true);
            Debug.Log("sus muertos");

        }
    }

    private void MarkAsCompleted(MissionsSO mission)
    {
        missions.MarkAsCompleted(mission);
    }
}
