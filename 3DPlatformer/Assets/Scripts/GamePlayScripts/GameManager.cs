using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;

    [SerializeField] private GameObject winPanel;
    
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }

        respawnPosition = new Vector3(0,0,0);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Respawn()
    {
        StartCoroutine("RespawnPlayer");
    }

    private IEnumerator RespawnPlayer()
    {
        PlayerController.instance.gameObject.SetActive(false);
        UIManager.instance.fadeToBlack = true;
        PlayerHealth.instance.ResetHealth();
        yield return new WaitForSeconds(2f);
        UIManager.instance.fadeFromBlack = true;
        PlayerController.instance.transform.position = respawnPosition;
        PlayerController.instance.gameObject.SetActive(true);
        PlayerHealth.instance.playerPartToInvins.SetActive(true);
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPosition = newPosition;
    }

    public void WinGame()
    {
        Cursor.visible = true;
        winPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlay");
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
}
