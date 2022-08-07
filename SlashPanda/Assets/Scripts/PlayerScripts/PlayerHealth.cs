using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] private GameObject[] healthBars;

   private int currentHealthBarIndex;

   private int health;

   private void Awake()
   {
      healthBars = GameObject.FindWithTag(TagManager.HEALTH_BAR_HOLDER).GetComponent<HealthBarHolder>().healthBars;
   }

   private void Start()
   {
      health = healthBars.Length;
      currentHealthBarIndex = health -1;
   }

   public void SubstractHealth()
   {
      healthBars[currentHealthBarIndex].SetActive(false);
      currentHealthBarIndex--;
      health--;

      if (health<=0)
      {
         GameObject.FindWithTag(TagManager.GAME_PLAY_CONTROLLER_TAG)
            .GetComponent<GameOverController>().GameOverShowPanel();
         
         Destroy(gameObject);
      }
   }

   public void AddHealth()
   {
      if (health==healthBars.Length)
      {
         return;
      }

      health++;
      currentHealthBarIndex = health - 1;
      healthBars[currentHealthBarIndex].SetActive(true);
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag(TagManager.HEALTH_TAG))
      {
         AddHealth();
         col.gameObject.SetActive(false);
      }
   }
}
