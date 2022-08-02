using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanging : MonoBehaviour
{
     private Rigidbody2D _rb;

     [SerializeField] private LayerMask collLayer;

     private RaycastHit2D playerCast;

     private bool collidedWithPlayer;

     private void Awake()
     {
         _rb = GetComponent<Rigidbody2D>();
     }

     private void Update()
     {
         CheckForPlayerCollision();
     }

     private void CheckForPlayerCollision()
     {
         if (collidedWithPlayer)
         {
             return;
         }

         playerCast = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, collLayer);

         if (playerCast.collider!=null)
         {
             collidedWithPlayer = true;

             _rb.gravityScale = 1f;
         }
     }

     private void OnTriggerEnter2D(Collider2D col)
     {
         if (col.CompareTag(TagManager.PLAYER_TAG))
         {
             Destroy(col.gameObject);
         }
     }
}
