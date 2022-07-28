using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
   public static GameOverUIController instance;

   [SerializeField] private Canvas playerInfoCanvas, shipsAndMeteorInfoCanvas, gameOverCanvas;

   [SerializeField] private Text shipDestroyedFinalInfoTxt, meteorsDestroyedFinalInfoTxt, waveFinalInfoTxt;

   [SerializeField] private Text shipDestroyedHighScore, meteorsDestroyedHighScore, waveHighScore;

   private void Awake()
   {
      if (instance==null)
      {
         instance = this;
      }
   }

   private void Start()
   {
      gameOverCanvas.enabled = false;
   }

   public void OpenGameOverPanel()
   {
      playerInfoCanvas.enabled = false;
      shipsAndMeteorInfoCanvas.enabled = false;

      gameOverCanvas.enabled = true;
      
      int shipsDestroyedFinal = GamePlayUIController.instance.GetShipDestroyedCount();
      int meteorsDestroyedFinal = GamePlayUIController.instance.GetMeteorsDestroyedCount();
      int waveCountFinal = GamePlayUIController.instance.GetWaveCount();
      waveCountFinal--;
      
      shipDestroyedFinalInfoTxt.text = "x" + shipsDestroyedFinal;
      meteorsDestroyedFinalInfoTxt.text = "x" + meteorsDestroyedFinal;
      waveFinalInfoTxt.text = "Wave: " + waveCountFinal;
      
      CalculateHighScore(shipsDestroyedFinal,meteorsDestroyedFinal,waveCountFinal);
   }

   public void PlayAgain()
   {
      SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
   }

   public void MainMenu()
   {
      SceneManager.LoadScene(TagManager.MAINMENU_LEVEL_NAME);
   }

   private void CalculateHighScore(int shipsDestroyedCurrent, int meteorsDestroyedCurrent, int waveCurrent)
   {
      
      
      int ships_Destroyed_HighScore = DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
      int meteors_Destroyed_HighScore = DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
      int wave_High_Score = DataManager.GetData(TagManager.WAVE_NUMBER_DATA);

      if (shipsDestroyedCurrent>ships_Destroyed_HighScore)
      {
         DataManager.SaveData(TagManager.SHIPS_DESTROYED_DATA,shipsDestroyedCurrent);
      }

      if (meteorsDestroyedCurrent>meteors_Destroyed_HighScore)
      {
         DataManager.SaveData(TagManager.METEORS_DESTROYED_DATA,meteorsDestroyedCurrent);
      }

      if (waveCurrent>wave_High_Score)
      {
         DataManager.SaveData(TagManager.WAVE_NUMBER_DATA,waveCurrent);
      }

      shipDestroyedHighScore.text = "x" + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
      meteorsDestroyedHighScore.text = "x" + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
      waveHighScore.text = "Wave:" + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);

   }
}
