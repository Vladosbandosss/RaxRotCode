using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] private float health = 100f;

   private PlayerMovement _playerMovement;

   [SerializeField] private Slider healthSlider;

   private void Awake()
   {
      _playerMovement = GetComponent<PlayerMovement>();
      healthSlider.maxValue = health;
      healthSlider.value = health;
   }

   public void TakeDamage(float damage)
   {
      if (health<=0)
      {
         return;
      }

      health -= damage;
      healthSlider.value = health;

      if (health<=0)
      {
         _playerMovement.PlayerDie();
         GameplayController.instance.RestartGame();
      }
   }
}
