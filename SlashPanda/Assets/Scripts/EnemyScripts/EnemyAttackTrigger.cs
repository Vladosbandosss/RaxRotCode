using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
   private EnemyAnimation _enemyAnim;

   private void Awake()
   {
      _enemyAnim = GetComponentInParent<EnemyAnimation>();
   }

   private void OnTriggerStay2D(Collider2D col)
   {
      if (col.CompareTag(TagManager.PLAYER_TAG))
      {
         _enemyAnim.PlayAttackAnimation();
      }
   }
}
