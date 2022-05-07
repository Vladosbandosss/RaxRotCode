using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WormMovement : MonoBehaviour
{
   private Rigidbody2D rb;

   [SerializeField] private float moveSpeed = 1f;

   private Vector3 tempPos;
   private Vector3 tempScale;

   [SerializeField] private LayerMask groundLayer;
   [SerializeField] private Transform groundCheck;

   private RaycastHit2D groundHit;

   private float checkDownDistance = 0.2f;

   private bool moveLeft;

   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();

      if (Random.Range(0, 2) > 0)
      {
         moveLeft = true;
      }
      else
      {
         moveLeft = false;
      }
   }

   private void Update()
   {
      HandleMovement();
      
      GroundCheck();
      
   }

   private void HandleMovement()
   {
      tempPos = transform.position;
      tempScale = transform.localScale;

      if (moveLeft)
      {
         tempPos.x -= moveSpeed * Time.deltaTime;
         tempScale.x = -1f;
      }
      else
      {
         tempPos.x += moveSpeed * Time.deltaTime;
         tempScale.x = 1f;
      }

      transform.position = tempPos;
      transform.localScale = tempScale;
   }

   private void GroundCheck()
   {
      groundHit = Physics2D.Raycast(groundCheck.position, Vector2.down, checkDownDistance, groundLayer);

      if (!groundHit)
      {
         moveLeft = !moveLeft;
      }
   }
}
