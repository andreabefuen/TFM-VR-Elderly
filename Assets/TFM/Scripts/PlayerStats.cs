using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    #region SINGLETON PATTERN
    public static PlayerStats _instance;
    public static PlayerStats Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerStats>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Game Manager");
                    _instance = container.AddComponent<PlayerStats>();
                }
            }
            DontDestroyOnLoad(_instance);

            return _instance;
        }
    }
    #endregion

    [SerializeField] private int startMoney = 0;

    private int money;
    public string playerName;

    public delegate void OnMoneyChange(int changeAmount, int finalMoney);
    public OnMoneyChange onMoneyChange;

    public int Money => money;

    public bool CanAfford(int amount) => money >= amount;

    void Start()
    {
        AddMoney(startMoney);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        onMoneyChange?.Invoke(amount, money);
    }

    public void ExpendMoney(int amount)
    {
        money -= amount;
        onMoneyChange?.Invoke(-amount, money);
    }
}
