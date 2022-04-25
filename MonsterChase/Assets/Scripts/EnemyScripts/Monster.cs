using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
   [HideInInspector] public float speed;

   private Rigidbody2D rb;

   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();

      speed = 7f;
   }

   private void FixedUpdate()
   {
      rb.velocity = new Vector2(speed, rb.velocity.y);
   }
}
