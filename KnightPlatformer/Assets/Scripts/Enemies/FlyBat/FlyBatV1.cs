using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyBatV1 : MonoBehaviour
{
   [SerializeField] private float moveSpeedHorizontal = 2f, moveSpeedVertical = 2f;

   [SerializeField] private float horizontalMovementTreshold = 7f, verticalMovementTreshold = 4f;

   private float minX, maxX, minY, maxY;

   private Vector3 tempPos;

   private bool moveHorizontal = true;
   private bool moveVertical;

   private SpriteRenderer sr;

   private void Awake()
   {
      sr = GetComponent<SpriteRenderer>();

      minX = transform.position.x - horizontalMovementTreshold;
      maxX = transform.position.x + horizontalMovementTreshold;

      minY = transform.position.y - verticalMovementTreshold;
      maxY = transform.position.y + verticalMovementTreshold;

      moveVertical = Random.Range(0, 2) > 0 ? true : false;

      if (Random.Range(0, 2) > 0)
      {
         moveSpeedHorizontal *= -1f;
      }
      
   }

   private void Update()
   {
      HandleHorizontalMovement();
      
      HandleVerticalMovement();
   }

   private void HandleHorizontalMovement()
   {
      if (moveHorizontal)
      {
         tempPos = transform.position;
         tempPos.x += moveSpeedHorizontal * Time.deltaTime;

         if (tempPos.x > maxX)
         {
            moveSpeedHorizontal *= -1f;
         }

         if (tempPos.x < minX)
         {
            moveSpeedHorizontal *= -1f;
         }
         
         transform.position = tempPos;

         if (moveSpeedHorizontal < 0)
         {
            sr.flipX = true;
         }else if (moveSpeedHorizontal > 0)
         {
            sr.flipX = false;
         }
      }
   }

   private void HandleVerticalMovement()
   {
      if (moveVertical)
      {
         tempPos = transform.position;
         tempPos.y += moveSpeedVertical * Time.deltaTime;
         
         if (tempPos.y > maxY)
         {
            moveSpeedVertical *= -1f;
         }

         if (tempPos.y < minY)
         {
            moveSpeedVertical *= -1f;
         }

         transform.position = tempPos;
      }
   }
   
   
   
   
   
   
}
