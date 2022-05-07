using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private LayerMask collisionLayer;

    private RaycastHit2D playerCast;

    private bool collidedWithPlayer;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckPlayerCollision();
    }

    private void CheckPlayerCollision()
    {
        if (collidedWithPlayer)
        {
            return;
        }

        playerCast = Physics2D.Raycast(transform.position, 
            Vector2.down, Mathf.Infinity, collisionLayer);

        if (playerCast.collider != null)
        {
            collidedWithPlayer = true;
            rb.gravityScale = 1f;
        }
        
    }
}
