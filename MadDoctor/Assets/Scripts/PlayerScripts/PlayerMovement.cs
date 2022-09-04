using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 3.5f;

   [SerializeField] private float minBoundX = -71f, maxBoundX = 71f, minBoundY = -3.3f, maxBoundY = 0f;

   private Vector3 tempPos;

   private float xAxis, yAxis;

   private PlayerAnimation _playerAnimation;

   [SerializeField] private float shootWaitTime = 0.5f;
   private float waitBeforeShooting;

   [SerializeField] private float moveWaitTime = 0.3f;
   private float waitBeforeMoving;

   private bool canMove = true;

   private bool playerDied;

   private float timeToDestroy = 2f;

   private PlayerShootingManager _playerShootingManager;

   private void Awake()
   {
      _playerAnimation = GetComponent<PlayerAnimation>();

      _playerShootingManager = GetComponent<PlayerShootingManager>();
   }

   private void Update()
   {
      if (playerDied)
      {
         return;
      }
      
      HandleMovement();
      
      HandleAnimation();
      
      HandleFacingDirection();
      
      HandleShooting();
      
      CheckIfCanMove();
   }

   private void HandleMovement()
   {
      xAxis = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS);
      yAxis = Input.GetAxisRaw(TagManager.VERTICAL_AXIS);
      
      if (!canMove)
      {
         return;
      }
      tempPos = transform.position;

      tempPos.x += xAxis * moveSpeed * Time.deltaTime;
      tempPos.y += yAxis * moveSpeed * Time.deltaTime;
      
      Bounds();

      transform.position = tempPos;
   }

   private void HandleAnimation()
   {
      if (!canMove)
      {
         return;
      }
      
      if (Mathf.Abs(xAxis)>0||Mathf.Abs(yAxis)>0)
      {
         _playerAnimation.PlayAnimation(TagManager.WALK_ANIMATION_NAME);
      }
      else
      {
         _playerAnimation.PlayAnimation(TagManager.IDLE_ANIMATION_NAME);
      }
   }

   private void HandleFacingDirection()
   {
      if (xAxis>0)
      {
         _playerAnimation.SetFacingDirection(true);
      }else if (xAxis < 0)
      {
         _playerAnimation.SetFacingDirection(false);
      }
   }

   private void StopMovement()
   {
      canMove = false;

      waitBeforeMoving = Time.time + moveWaitTime;
   }

   private void Shoot()
   {
      waitBeforeShooting = Time.time + shootWaitTime;
      StopMovement();
      
      _playerAnimation.PlayAnimation(TagManager.SHOOT_ANIMATION_NAME);
      
      _playerShootingManager.Shoot(transform.localScale.x);
      
   }

   private void CheckIfCanMove()
   {
      if (Time.time>waitBeforeMoving)
      {
         canMove = true;
      }
   }

   private void HandleShooting()
   {
      if (Input.GetKeyDown(KeyCode.K))
      {
         if (Time.time>waitBeforeShooting)
         {
            Shoot();
         }
      }
   }

   private void Bounds()
   {
      if (tempPos.x<minBoundX)
      {
         tempPos.x = minBoundX;
      }

      if (tempPos.x>maxBoundX)
      {
         tempPos.x = maxBoundX;
      }

      if (tempPos.y<minBoundY)
      {
         tempPos.y = minBoundY;
      }

      if (tempPos.y>maxBoundY)
      {
         tempPos.y = maxBoundY;
      }
   }

   public void PlayerDie()
   {
      playerDied = true;
      
      _playerAnimation.PlayAnimation(TagManager.DEATH_ANIMATION_NAME);
      Invoke("DestroyPlayer",timeToDestroy);
   }

   private void DestroyPlayer()
   {
      Destroy(gameObject);
   }
   
}
