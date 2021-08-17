using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using UnityEngine;

public class Missions : MonoBehaviour
{
    #region SINGLETON
    public static Missions _instance = null;

    public static Missions Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Missions>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Missions");
                    _instance = container.AddComponent<Missions>();
                }
            }

            return _instance;
        }
    }
    #endregion

    private Dictionary<MissionsSO, string> missions = new Dictionary<MissionsSO, string>();

    public delegate void OnMissionStateChange();
    public OnMissionStateChange onMissionStateChange;

    public Dictionary<MissionsSO, string> GetMissions => missions;

    public void SetDictionary(Dictionary<MissionsSO, string> loadMissions) => missions = loadMissions;

    public void AddToMissions(MissionsSO mission, bool state)
    {
        if (!missions.ContainsKey(mission))
        {

            missions.Add(mission, BoolToString(state));
            mission.MissionAccepted();
        }
        else
        {
            Debug.Log("Change state of mission");
            missions[mission] = BoolToString(state);

        }
        onMissionStateChange?.Invoke();

    }

    public void RemoveFromMissions(MissionsSO mission, bool state)
    {
        if (!missions.ContainsKey(mission))
        {
            throw new System.Exception("Missions dictionary doesnt contain that");
        }
        string stateStr = BoolToString(state);
        if(missions[mission] != stateStr)
        {
            missions[mission] = stateStr;
        }
        else
        {
            Debug.Log("That missions is already with the same state");

        }
          onMissionStateChange?.Invoke();
    }

    public void MarkAsCompleted(MissionsSO mission)
    {
        if(!Inventory.Instance.HasNumberOfItem(mission.ItemNeeded(), mission.Cuantity))
        {
            Debug.Log("Not enough cuantity of that item");
            return;
        }
        Inventory.Instance.RemoveFromInventory(mission.ItemNeeded(), mission.Cuantity);
        RemoveFromMissions(mission, true);
        Debug.Log("FinishTask");

    }

    public static string BoolToString(bool b)
    {
        return b ? "true" : "false";
    }

}


 