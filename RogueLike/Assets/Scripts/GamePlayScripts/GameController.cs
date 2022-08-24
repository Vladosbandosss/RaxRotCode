using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
