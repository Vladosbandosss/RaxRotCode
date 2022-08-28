using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private GameObject showGoPanel;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        showGoPanel.SetActive(false);
    }

    public void GameOver()
    {
        showGoPanel.SetActive(true);
    }
}
