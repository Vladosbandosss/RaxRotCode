using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool moveOnX, moveOnY;

    private float minX, maxX;
    private float minY, maxY;

    [SerializeField] private float moveSpeed = 8f;

    [SerializeField] private float horizontalMovementTreshold = 8f;
    [SerializeField] private float verticalMovementTreshold = 6f;

    private Vector3 tempMovementHorizontal;
    private Vector3 tempMovementVertical;

    private bool moveLeft;
    private bool moveUp;

    private void Start()
    {
        minX = transform.position.x - horizontalMovementTreshold;
        maxX = transform.position.x + horizontalMovementTreshold;

        minY = transform.position.y-verticalMovementTreshold;
        maxY = transform.position.y;

        if (Random.Range(0,2)>0)
        {
            moveLeft = true;
        }
    }

    private void Update()
    {
        HandleEnemyHorizontalMovement();
        
        HandleEnemyVerticalMovement();
    }

    private void HandleEnemyHorizontalMovement()
    {
        if (!moveOnX)
        {
            return;
        }

        if (moveLeft)
        {
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x -= moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if (tempMovementHorizontal.x<minX)
            {
                moveLeft = !moveLeft;
            }
        }
        else
        {
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x += moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if (tempMovementHorizontal.x>maxX)
            {
                moveLeft = !moveLeft;
            }
        }
    }

    private void HandleEnemyVerticalMovement()
    {
        if (!moveOnY)
        {
            return;
        }

        if (moveUp)
        {
            tempMovementVertical = transform.position;
            tempMovementVertical.y += moveSpeed * Time.deltaTime;
            transform.position = tempMovementVertical;

            if (tempMovementVertical.y>maxY)
            {
                moveUp = !moveUp;
            }
        }
        else
        {
            tempMovementVertical = transform.position;
            tempMovementVertical.y -= moveSpeed * Time.deltaTime;
            transform.position = tempMovementVertical;

            if (tempMovementVertical.y<minY)
            {
                moveUp = !moveUp;
            }
        }
    }
}