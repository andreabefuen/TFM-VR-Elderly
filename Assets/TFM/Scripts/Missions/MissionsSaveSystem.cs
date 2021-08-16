using System.Collections;
using System.Collections.Generic;
using System.IO;
using TFM.ScriptableObjects;
using UnityEngine;

public class MissionsSaveSystem : MonoBehaviour
{
    [SerializeField] private Missions missions = null;

    private static Dictionary<int, MissionsSO> allMissionsDictionary = new Dictionary<int, MissionsSO>();
    private static int HashMission(MissionsSO mission) => Animator.StringToHash(mission.MissionName);
    const char SPLIT_CHAR = '_';
    private static string FILE_PATH = "NULL!";

    private void Awake()
    {
        FILE_PATH = Application.persistentDataPath + "/Missions.txt";

        CreateMissionsDictionary();
        if (File.Exists(FILE_PATH))
        {
            missions.SetDictionary(LoadMissions());
        }
    }


    private void OnDisable()
    {
        SaveMissions();
    }

    void CreateMissionsDictionary()
    {
        MissionsSO[] allMissions = Resources.FindObjectsOfTypeAll<MissionsSO>();

        foreach (MissionsSO m in allMissions)
        {
            int key = HashMission(m);
            if (!allMissionsDictionary.ContainsKey(key))
                allMissionsDictionary.Add(key, m);
        }
    }

    public void SaveMissions()
    {
        Debug.Log("Save missions in " + FILE_PATH);
        using (StreamWriter sw = new StreamWriter(FILE_PATH))
        {
            foreach (KeyValuePair<MissionsSO, string> kvp in missions.GetMissions)
            {
                MissionsSO mission = kvp.Key;
                string state = kvp.Value;

                string missionID = HashMission(mission).ToString();

                sw.WriteLine(missionID + SPLIT_CHAR + state);
            }
        }
    }
    internal Dictionary<MissionsSO, string> LoadMissions()
    {
        if (!File.Exists(FILE_PATH))
        {
            Debug.LogWarning("This file doesn't exist!");
            return null;
        }

        Dictionary<MissionsSO, string> missions = new Dictionary<MissionsSO, string>();

        string line = "";
        using(StreamReader sr = new StreamReader(FILE_PATH))
        {
            while((line = sr.ReadLine() ) != null)
            {
                int key = int.Parse(line.Split(SPLIT_CHAR)[0]);
                MissionsSO mission = allMissionsDictionary[key];
                string state = line.Split(SPLIT_CHAR)[1];

                missions.Add(mission, state);
            }
        }

        return missions;
    }
}
