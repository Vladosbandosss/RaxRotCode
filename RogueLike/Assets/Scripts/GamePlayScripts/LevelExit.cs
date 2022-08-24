using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.PLAYER_TAG))
        {
            PlayerController.instance.CanMove = false;
            LevelManager.instanse.nextLevel = TagManager.GAME_PLAY_SCENE;
            LevelManager.instanse.LoadLevelEnd();
        }
    }
}
