using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
   [SerializeField] private GameObject cpOn, cpOFF;

   public CheckPoint[] checkPoints;
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag(TagManager.PLAYER_TAG))
      {
         GameManager.instance.SetSpawnPoint(transform.position);
         AudioManager.instance.PlayCheckPoint();
         cpOFF.SetActive(false);
         cpOn.SetActive(true);
      }
   }
}
