using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
   private Animator _anim;
   private SpriteRenderer _sr;

   private void Awake()
   {
      _anim = GetComponent<Animator>();

      _sr = GetComponent<SpriteRenderer>();
   }

   public void PlayWalk(int walk)
   {
      _anim.SetInteger(TagManager.WALK_ANIMATION_PARAM,walk);
   }

   public void ChangeFacingDirection(int direction)
   {
      if (direction > 0)
      {
         _sr.flipX = false;
      }else if (direction<0)
      {
         _sr.flipX = true;
      }
   }

   public void PlayJumpAndFall(int jumpFall)
   {
      _anim.SetInteger(TagManager.JUMP_ANIMATION_PARAM,jumpFall);
   }
   
   public void PlayAnimWithName(string animName)
   {
      _anim.Play(animName);
   }
}
