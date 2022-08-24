using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void PlayGame()
   {
      SceneManager.LoadScene(TagManager.GAME_PLAY_SCENE);
   }

   public void ExitGame()
   {
      Application.Quit();
   }
}
