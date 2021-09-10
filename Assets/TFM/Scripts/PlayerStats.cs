using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    #region SINGLETON PATTERN

    private static PlayerStats _instance;

    public static PlayerStats Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
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
