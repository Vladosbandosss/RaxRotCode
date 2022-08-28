 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static Money instance;
    public int currentMoney=200;

    private bool canBuyTower;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        UIController.instance.goldText.text = "Gold: " + currentMoney;
    }

    public void GiveMoney(int ammount)
    {
        currentMoney += ammount;
        UIController.instance.goldText.text = "Gold: " + currentMoney;
    }

    public bool SpendMoney(int ammount)
    {
        bool canSpend = false;

        if (ammount<=currentMoney)
        {
            canSpend = true;
            currentMoney -= ammount;
            UIController.instance.goldText.text = "Gold: " + currentMoney;
        }

        return canSpend;
    }
    
}
