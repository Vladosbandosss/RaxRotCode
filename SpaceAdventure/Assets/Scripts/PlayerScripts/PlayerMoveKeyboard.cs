using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{
    [SerializeField] private float speed = 600f;

    private Rigidbody2D _rb;

    private float minMoveX = -50f, maxMoveX = 50f;
    private float minMoveY = -25f, maxMoveY = 0f;

    private Vector2 tempPos;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckBorders();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(transform.up*speed);
        } 
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(-transform.up*speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(transform.right*speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(-transform.right*speed);
        }
    }

    private void CheckBorders()
    {
        tempPos = transform.position;

        if (tempPos.x>maxMoveX)
        {
            tempPos.x = maxMoveX;
            transform.position = tempPos;
        }
        
        if (tempPos.x<minMoveX)
        {
            tempPos.x = minMoveX;
            transform.position = tempPos;
        }
        
        if (tempPos.y>maxMoveY)
        {
            tempPos.y = maxMoveY;
            transform.position = tempPos;
        }
        
        if (tempPos.y<minMoveY)
        {
            tempPos.y = minMoveY;
            transform.position = tempPos;
        }

        
    }
}
