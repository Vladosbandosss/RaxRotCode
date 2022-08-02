using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WormSoldier : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector3 tempPos;
    private Vector3 tempScale;

    private bool moveLeft;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    private RaycastHit2D groundHit;

    private void Awake()
    {
        
        moveLeft = Random.Range(0, 2) > 0 ? true : false;
    }

    private void Update()
    {
        HandleMovement();
        
        CheckForGround();
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

    private void CheckForGround()
    {
        groundHit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.5f, groundLayer);

        if (!groundHit)
        {
            moveLeft = !moveLeft;
        }
    }
}
