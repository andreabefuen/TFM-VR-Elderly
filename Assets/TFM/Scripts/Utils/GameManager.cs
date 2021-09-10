using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public TMP_Text channelIDText;

    #region SINGLETON PATTERN
    public static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Game Manager");
                    _instance = container.AddComponent<GameManager>();
                }
            }
            DontDestroyOnLoad(_instance);

            return _instance;
        }
    }
    #endregion

    public void OnExitClickButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }

    public void OnStartGameClickButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeChannelID(string channelIDString)
    {
        if(channelIDText != null)
        {
            channelIDText.text = "Channel ID: " + channelIDString;
        }
    }

    public void OnVolumenChange(int value)
    {
        GetComponent<AudioGameManager>().ChangeVolumen(value);
    }

}
