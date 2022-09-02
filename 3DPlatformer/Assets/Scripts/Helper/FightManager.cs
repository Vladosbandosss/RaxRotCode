using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;

    [SerializeField] private GameObject endLevel;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    public void WinGame()
    {
        endLevel.SetActive(true);
    }
}
