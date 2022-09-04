using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField] private Text enemyKillCountTxt;
    private int killCount;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    public void EnemyKilled()
    {
        killCount++;
        enemyKillCountTxt.text = "ENEMIES KILLED: "+ killCount;
    }

    public void RestartGame()
    {
       Invoke("Restart",3f);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
