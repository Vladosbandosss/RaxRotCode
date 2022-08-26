using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private string playerTag = "Player";
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(playerTag))
        {
            SceneManager.LoadScene("GamePlay");
        }
    }
}
