using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE_NAME);
    }
}
