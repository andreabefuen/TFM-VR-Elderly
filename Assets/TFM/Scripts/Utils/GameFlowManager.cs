using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    #region SINGLETON PATTERN
    public static GameFlowManager _instance;
    public static GameFlowManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameFlowManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Game Manager");
                    _instance = container.AddComponent<GameFlowManager>();
                }
            }
            DontDestroyOnLoad(_instance);

            return _instance;
        }
    }
    #endregion
    public void SaveCurrentTime()
    {
        PlayerPrefs.SetString("Date", System.DateTime.Now.ToString());
    }

    public void SaveCurrentTimeCrop(Crops crop)
    {
        PlayerPrefs.SetString(crop.ToString() + "date", System.DateTime.Now.ToString());
    }

    public double MinutesPassed()
    {
        var getLastTime = PlayerPrefs.GetString("Date");
        var currentTime = System.DateTime.Now;
        var lastTime = System.DateTime.Parse(getLastTime);

        var differenceTime = currentTime - lastTime;
        return differenceTime.TotalMinutes;
    }

    public double MinutesPassedCrop(Crops crop)
    {
        if(!PlayerPrefs.HasKey(crop.ToString() + "date")) { SaveCurrentTimeCrop(crop); return 0; }
        var getLastTime = PlayerPrefs.GetString(crop.ToString() + "date");
        var currentTime = System.DateTime.Now;
        var lastTime = System.DateTime.Parse(getLastTime);

        var differenceTime = currentTime - lastTime;
        return differenceTime.TotalMinutes;
    }
    public int MinutesIntPassedCrop(Crops crop)
    {
        if (!PlayerPrefs.HasKey(crop.ToString() + "date")) { SaveCurrentTimeCrop(crop); return 0; }

        var getLastTime = PlayerPrefs.GetString(crop.ToString() + "date");
        var currentTime = System.DateTime.Now;
        var lastTime = System.DateTime.Parse(getLastTime);

        var differenceTime = currentTime - lastTime;
        Debug.Log("Minutes passed: " + differenceTime.Minutes);
        return differenceTime.Minutes;
    }
}

public enum Crops
{
    Calabaza,
    Hongos,
    Tomates,
    Berenjenas, 
    Patatas
}
