using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
   [SerializeField] private float rotateSpeed = 100f;

   [SerializeField] private GameObject playerHealFX;
   [SerializeField] private Transform healSpawnPosition;

   private bool canPick;
   private void Update()
   {
      transform.Rotate(0f,rotateSpeed*Time.deltaTime,0f);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag(TagManager.PLAYER_TAG))
      {
         if (other.GetComponent<PlayerHealth>().maxHealth==other.GetComponent<PlayerHealth>().currentHealth)
         {
            return;
         }
         else
         {
            Instantiate(playerHealFX, healSpawnPosition.position, Quaternion.identity);
            PlayerHealth.instance.HealPlayer();
            Destroy(gameObject);
         }
      }
   }
}
