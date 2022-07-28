using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovementInPoints : MonoBehaviour
{
    [SerializeField] private Transform[] movementPoints;
    private int currentMoveIndex;

    private Vector3 targetPosition;

    [SerializeField] private float moveSpeed = 8f;

    [SerializeField] private bool moveRandomly;

    private float checkPosition = 0.1f;

    private void Start()
    {
        SetTargetPosition();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position,targetPosition)<checkPosition)
        {
            SetTargetPosition();
        }
        
    }

    private void SetTargetPosition()
    {
        if (moveRandomly)
        {
            SelectRandomPosition();
        }
        else
        {
            SelectPointToPoint();
        }
    }

    private void SelectRandomPosition()
    {
        while (movementPoints[currentMoveIndex].position==targetPosition)
        {
            currentMoveIndex = Random.Range(0, movementPoints.Length);
        }

        targetPosition = movementPoints[currentMoveIndex].position;
    }

    private void SelectPointToPoint()
    {
        if (currentMoveIndex==movementPoints.Length)
        {
            currentMoveIndex = 0;
        }

        targetPosition = movementPoints[currentMoveIndex].position;
        
        currentMoveIndex++;

       
    }
}
