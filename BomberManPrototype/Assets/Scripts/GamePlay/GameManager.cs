using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score;
    private int lives;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text liveText;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }

        lives = PlayerHealth.instance.heath;
        scoreText.text = "Score: 0";
        liveText.text = "Lives: " + lives;
    }
    
    public void PlayerDie()
    {
        print("GOPomer");
    }

    public void IncreaseScore()
    {
        score++;
        print(score);
        scoreText.text = "Score: " + score;
    }

    public void DecreasePlayerLives()
    {
        lives--;
        liveText.text = "Lives: " + lives;
    }
}
