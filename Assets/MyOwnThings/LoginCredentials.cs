using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VivoxUnity;
using System.ComponentModel;
using System;
using TMPro;

public class LoginCredentials : MonoBehaviour
{
    VivoxUnity.Client client;
    private Uri server = new Uri("https://mt1s.www.vivox.com/api2");
    private string issuer = "andrea4324-vr08-dev";
    private string domain = "mt1s.vivox.com";
    private string tokenKey = "flex032";
    private TimeSpan timeSpan = TimeSpan.FromSeconds(90);

    private ILoginSession loginSession;
    private IChannelSession channelSession;

    [SerializeField] TextMeshProUGUI txt_Username;
    [SerializeField] TextMeshProUGUI txt_ChannelName;
    [SerializeField] TextMeshProUGUI txt_Message;
    [SerializeField] TMP_InputField input_Username;
    [SerializeField] TMP_InputField input_ChannelName;
    [SerializeField] TMP_InputField input_SendMessages;
    [SerializeField] TextMeshProUGUI txt_Status;

    public delegate void OnLogginUser(string userName);
    public event OnLogginUser OnLogginUserEvent;

    public delegate void OnChannelJoin(string channel);
    public event OnChannelJoin OnChannelJoinEvent;

    public delegate void OnStatusChange(bool isLoggin, bool isChannel);
    public event OnStatusChange OnStatusChangeEvent;


    private string channelName;
    private string userName;

    private void Awake()
    {
        client = new Client();
        client.Uninitialize();
        client.Initialize();
        DontDestroyOnLoad(this);
        AddListeners();

        UpdateStatusText(false, false);
    }

    private void OnApplicationQuit()
    {
        client.Uninitialize();
        RemoveListeners();
    }

    private void AddListeners()
    {
        OnLogginUserEvent += UpdateUserNameText;
        OnStatusChangeEvent += UpdateStatusText;
        OnChannelJoinEvent += UpdateChannelNameText;
    }
    private void RemoveListeners()
    {
        OnLogginUserEvent -= UpdateUserNameText;
        OnStatusChangeEvent -= UpdateStatusText;
        OnChannelJoinEvent -= UpdateChannelNameText;


    }

    public void Bind_Login_Callback_Listeners(bool _bind, ILoginSession _loginSession)
    {
        if (_bind)
        {
            _loginSession.PropertyChanged += Login_Status;

        }
        else
        {
            _loginSession.PropertyChanged -= Login_Status;

        }
    }

    public void Bind_Channel_Callback_Listeners(bool _bind, IChannelSession _channelSession)
    {
        if (_bind)
        {
            _channelSession.PropertyChanged += OnChannelStatusChanged;
        }
        else
        {
            _channelSession.PropertyChanged -= OnChannelStatusChanged;
        }
    }

    #region Login Methods
    public void LoginUser()
    {
        //Login("Testname");
        Login(input_Username.text);
    }

    private void Login(string username)
    {
        AccountId accountId = new AccountId(issuer, username, domain);
        loginSession = client.GetLoginSession(accountId);
        
        Bind_Login_Callback_Listeners(true, loginSession);

        loginSession.BeginLogin(server, loginSession.GetLoginToken(tokenKey, timeSpan), ar =>
        {
            try
            {
                loginSession.EndLogin(ar);
            }
            catch (Exception e)
            {
                Bind_Login_Callback_Listeners(false, loginSession);
                Debug.Log(e.Message);
            }
            // run more code here 
        });

    }
    public void LoginResult()
    {

    }

    public void Logout()
    {
        loginSession.Logout();
        Bind_Login_Callback_Listeners(false, loginSession);
        OnLogginUserEvent.Invoke("User name");
        OnStatusChangeEvent.Invoke(false, false);
    }

    public void Login_Status(object sender, PropertyChangedEventArgs loginArgs)
    {
        var source = (ILoginSession)sender;
        userName = loginSession.LoginSessionId.Name;

        switch (source.State)
        {
            case LoginState.LoggedOut:
                Debug.Log("LOGGED OUT");

                break;
            case LoginState.LoggedIn:
                Debug.Log($"Logged In {loginSession.LoginSessionId.Name}");
                input_Username.text = loginSession.LoginSessionId.Name;
                OnLogginUserEvent.Invoke("Conectado como: " + userName);
                OnStatusChangeEvent.Invoke(true, false);

                break;
            case LoginState.LoggingIn:
                Debug.Log("LOGGED IN");

                break;
            case LoginState.LoggingOut:
                Debug.Log("LOGGing OUT");
                break;
            default:
                break;
        }
    }
    #endregion

    #region Join Channel Methods

    public void JoinChannel(string channelName, bool isAudio, bool isText, bool switchTransmission, ChannelType channelType)
    {
        ChannelId channelId = new ChannelId(issuer, channelName, domain, channelType);
        channelSession = loginSession.GetChannelSession(channelId);
        Bind_Channel_Callback_Listeners(true, channelSession);
        
        channelSession.BeginConnect(isAudio, isText, switchTransmission, channelSession.GetConnectToken(tokenKey, timeSpan), ar =>
        {
            try
            {
                channelSession.EndConnect(ar);
            }
            catch(Exception e)
            {
                Bind_Channel_Callback_Listeners(false, channelSession);
                Debug.Log(e.Message);
            }
        });
    }

    public void LeaveChannel(IChannelSession channelToDisconnect, string channelName)
    {
        channelToDisconnect.Disconnect();
        loginSession.DeleteChannelSession(new ChannelId(issuer, channelName, domain));

    }

    public void OnChannelStatusChanged(object sender, PropertyChangedEventArgs loginArgs)
    {
        IChannelSession source = (IChannelSession)sender;
        channelName = source.Channel.Name;

        switch (source.ChannelState)
        {
            case ConnectionState.Disconnected:
                Debug.Log($" {source.Channel.Name} Disconnected");
                OnChannelJoinEvent.Invoke("Channel Name");
                OnStatusChangeEvent.Invoke(true, false);
                break;
            case ConnectionState.Connecting:
                Debug.Log("Connecting");

                break;
            case ConnectionState.Connected:
                Debug.Log($" {source.Channel.Name} Connected");
                input_ChannelName.text = source.Channel.Name;
                channelName = source.Channel.Name;
                OnChannelJoinEvent.Invoke("Conectado al canal: "+channelName);
                OnStatusChangeEvent.Invoke(true, true);
                break;
            case ConnectionState.Disconnecting:
                Debug.Log($" {source.Channel.Name} disconnecting");
                break;
            default:
                break;
        }
    }
    public void OnJoinChannelButtonClicked()
    {
        JoinChannel(input_ChannelName.text, true, true, true, ChannelType.NonPositional);
    }
    public void OnLeaveChannelButtonClicked()
    {
        LeaveChannel(channelSession, input_ChannelName.text);
    }

    #endregion

    public void MuteMicrophone()
    {
        client.AudioInputDevices.Muted = true;
        txt_Status.text = "Tienes el micrófono " + (client.AudioInputDevices.Muted ? "<color=red>silenciado</color>." : "<color=green>activado</color>.");

    }
    public void UnmuteMicrophone()
    {
        client.AudioInputDevices.Muted = false;
        txt_Status.text = "Tienes el micrófono " + (client.AudioInputDevices.Muted ? "<color=red>silenciado</color>." : "<color=green>activado</color>.");
    }


    private void UpdateUserNameText(string textInUser)
    {
        txt_Username.text = textInUser;
        input_Username.gameObject.SetActive(!input_Username.gameObject.activeInHierarchy);
    }

    private void UpdateChannelNameText(string channelName)
    {
        txt_ChannelName.text = channelName;
        input_ChannelName.gameObject.SetActive(!input_ChannelName.gameObject.activeInHierarchy);
    }

    private void UpdateStatusText(bool isLoggin, bool isChannel)
    {

        if (isLoggin && isChannel)
        {
            txt_Status.text = $"Te has conectado como <color=green>{userName}</color>. \n" +
                $"Te has conectado al canal <color=green> {channelName}</color>. \n" ;
        }
        else if (isLoggin)
        {
            txt_Status.text = $"Te has conectado como <color=green>{userName}</color>. \n";
        }
        else
        {
            txt_Status.text = $"Por favor, rellena los campos anteriores. \n";
        }
        txt_Status.text += "Tienes el micrófono " + (client.AudioInputDevices.Muted? "<color=red>silenciado</color>." : "<color=green>activado</color>.");
    }
}
