using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas, highScoreCanvas;

    [SerializeField] private Text shipsDestroyedHighScore, meteorsDestroyedHighScore, wavesSurvivedHighScore;

    private void Start()
    {
        highScoreCanvas.enabled = false;
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
    }

    public void OpenCloseHighScoreCanvas(bool open)
    {
        mainMenuCanvas.enabled = !open;
        highScoreCanvas.enabled = open;

        if (open)
        {
            DisplayHughScore();
        }
    }

    private void DisplayHughScore()
    {
        shipsDestroyedHighScore.text = "x" + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        meteorsDestroyedHighScore.text = "x" + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        wavesSurvivedHighScore.text = "Wave:" + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
    }
}
