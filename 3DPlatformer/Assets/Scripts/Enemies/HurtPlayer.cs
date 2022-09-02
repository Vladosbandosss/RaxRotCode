using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag(TagManager.PLAYER_TAG))
      {
         other.GetComponent<PlayerHealth>().HurtPlayer();
      }
   }
}
