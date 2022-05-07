using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyBatV2 : MonoBehaviour
{
   [SerializeField] private float minX = -8f, maxX = 8f, minY = -4f, maxY = 4f;

   private Vector3 targetPos;

   [SerializeField] private float moveSpeed = 2f;

   private float prevPosX;

   private SpriteRenderer sr;

   private void Awake()
   {
      sr = GetComponent<SpriteRenderer>();
   }

   private void Update()
   {
      MoveToTarget();
   }

   private void MoveToTarget()
   {
      transform.position = Vector3.MoveTowards(
         transform.position, targetPos, moveSpeed * Time.deltaTime);

      if (Vector3.Distance(transform.position, targetPos) < 0.1f)
      {
         targetPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
         prevPosX = transform.position.x;
      }
      
      ChangeDirection();
   }

   private void ChangeDirection()
   {
      if (transform.position.x > prevPosX)
      {
         sr.flipX = false;
      }else if (transform.position.x < prevPosX)
      {
         sr.flipX = true;
      }
   }
}
