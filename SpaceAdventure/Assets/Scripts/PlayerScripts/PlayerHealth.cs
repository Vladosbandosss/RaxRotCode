using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] private float playerMaxHealth = 100f;

   private float playerHealth;

   [SerializeField] private GameObject playerExplosionFX;

   [SerializeField] private GameObject playerDamageFx;

   private float minDamage = 10f, maxDamage = 40f;

   private Collectables _collectables;

   private Slider playerHealthSlider;

   private void Awake()
   {
      playerHealthSlider = GameObject.FindWithTag(TagManager.PLAYER_HEALTH_SLIDER).GetComponent<Slider>();
      
      playerHealth = playerMaxHealth;

      playerHealthSlider.minValue = 0f;
      playerHealthSlider.maxValue = playerHealth;
      playerHealthSlider.value = playerHealth;
      
   }

   public void TakeDamage(float damageAmount)
   {
      playerHealth -= damageAmount;
      playerHealthSlider.value = playerHealth;
      
      if (playerHealth<=0)
      {
         //Dead
         Instantiate(playerExplosionFX, transform.position, Quaternion.identity);
         
         GameOverUIController.instance.OpenGameOverPanel();
         
         SoundManager.instance.PlayDestroySound();
         
         Destroy(gameObject);
      }
      else
      {
         Instantiate(playerDamageFx, transform.position, Quaternion.identity);
         
         SoundManager.instance.PlayDamageSound();
      }
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag(TagManager.METEOR_TAG))
      {
         TakeDamage(Random.Range(minDamage,maxDamage));
         
         Destroy(col.gameObject);
      }

      if (col.CompareTag(TagManager.COLLECTABLE_TAG))
      {
         _collectables = col.GetComponent<Collectables>();
         
         
         SoundManager.instance.PlayPickUpSound();

         if (_collectables.type==CollectableType.Health)
         {
            playerHealth += _collectables.healthValue;
            playerHealthSlider.value = playerHealth;
            
            if (playerHealth>playerMaxHealth)
            {
               playerHealth = playerMaxHealth;
            }
            Destroy(col.gameObject);
         }
         
         
      }
   }
}
