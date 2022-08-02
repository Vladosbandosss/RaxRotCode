using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Key : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag(TagManager.PLAYER_TAG))
      {
        Lock.instance.PlayOpenAnim();
        
        Destroy(gameObject);
      }
   }
}
