using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;

    [SerializeField] private Text currentScore, bestScore;

    private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    public void GameOverShowPanel()
    {
        Time.timeScale = 0f;
        
        _scoreCounter.CanCountScore = false;
        
        gameOverCanvas.enabled = true;
        
        DisplayScore();
        
        CheckToUnlockCharacters(_scoreCounter.GetScore());
    }

    public void DisplayScore()
    {
        int highScore = DataManager.GetData(TagManager.HIGHSCORE_DATA);
        if (_scoreCounter.GetScore()>highScore)
        {
            DataManager.SaveData(TagManager.HIGHSCORE_DATA,_scoreCounter.GetScore());
        }
        
        currentScore.text = "Score: " + _scoreCounter.GetScore() + "m";
        bestScore.text = "Best: " + DataManager.GetData(TagManager.HIGHSCORE_DATA);
    }

    private void CheckToUnlockCharacters(int score)
    {
        GamePlayController.instance.CheckToUnlockCharacter(score);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
    }

    public void ExitGame()
    {   Time.timeScale = 1f;
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE_NAME);
    }
}
