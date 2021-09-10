using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VivoxUnity;
using System.ComponentModel;
using UnityEngine.Android;

public class LoginCredentialsVivox : MonoBehaviour
{
    VivoxUnity.Client client;
    private Uri server = new Uri("https://mt1s.www.vivox.com/api2");
    private string issuer = "andrea4324-vr08-dev";
    private string domain = "mt1s.vivox.com";
    private string tokenKey = "flex032";
    private TimeSpan timeSpan = TimeSpan.FromSeconds(90);

    private ILoginSession loginSession;
    private IChannelSession channelSession;

    [SerializeField] private string userName;
    [SerializeField] private string channelName;


    private void Awake()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
        client = new Client();
        client.Uninitialize();
        client.Initialize();
        //DontDestroyOnLoad(this);

        channelName = CreateRandomString(4);


        StartCoroutine("Initialize");

        this.GetComponent<GameManager>().ChangeChannelID(channelName);
    }

    IEnumerator Initialize()
    {
        LoginUser();
        yield return new WaitUntil(()=> loginSession.State == LoginState.LoggedIn);
        OnJoinChannelButtonClicked();

    }

    private void OnApplicationQuit()
    {
        client.Uninitialize();
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
        Login(userName);
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

    }

    public void Login_Status(object sender, PropertyChangedEventArgs loginArgs)
    {
        var source = (ILoginSession)sender;

        switch (source.State)
        {
            case LoginState.LoggedOut:
                Debug.Log("LOGGED OUT");

                break;
            case LoginState.LoggedIn:
                Debug.Log($"Logged In {loginSession.LoginSessionId.Name}");
                
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
            catch (Exception e)
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

        switch (source.ChannelState)
        {
            case ConnectionState.Disconnected:
                Debug.Log($" {source.Channel.Name} Disconnected");
                break;
            case ConnectionState.Connecting:
                Debug.Log("Connecting");

                break;
            case ConnectionState.Connected:
                Debug.Log($" {source.Channel.Name} Connected");
               

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
        JoinChannel(channelName, true, true, true, ChannelType.NonPositional);
    }
    public void OnLeaveChannelButtonClicked()
    {
        LeaveChannel(channelSession, channelName);
    }

    #endregion

    private string CreateRandomString(int stringLength = 10)
    {
        int _stringLength = stringLength - 1;
        string randomString = "";
        string[] characters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        for (int i = 0; i <= _stringLength; i++)
        {
            randomString = randomString + characters[UnityEngine.Random.Range(0, characters.Length)];
        }
        Debug.Log(randomString);
        return randomString;
        
    }
}
