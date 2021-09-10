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
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
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

    public void OnPrincipalMenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeChannelID(string channelIDString)
    {
        if(channelIDText != null)
        {
            channelIDText.text = "Channel ID: " + channelIDString;
        }
    }

    public void OnVolumenChange(float value)
    {
        GetComponent<AudioGameManager>().ChangeVolumen(value);
    }

}
