using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    private float delayTime = 1f;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        print("pedorahnulsa");
        Invoke("RestartLevel",delayTime);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
