using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMoney : MonoBehaviour
{
    private PlayerStats playerStats = null;
    [SerializeField]  private TextMeshProUGUI moneyText = null;

    void Start()
    {
        playerStats = PlayerStats.Instance;

        playerStats.onMoneyChange += UpdateMoneyUI;

    }

    private void UpdateMoneyUI(int changeAmount, int finalMoney)
    {
        moneyText.text = finalMoney.ToString();
    }

}
