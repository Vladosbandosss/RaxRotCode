using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instanse;

    [SerializeField] private float waitToLoad = 4f;

    public  string nextLevel;

    private void Awake()
    {
        if (instanse==null)
        {
            instanse = this;
        }
    }

    public void LoadLevelEnd()
    {
        StartCoroutine("LoadlvlEnd");
    }

    private IEnumerator LoadlvlEnd()
    {
        UIController.instance.StartFadeToBlack();
        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(nextLevel);
    }
    
    
    
    
}
