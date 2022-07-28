using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovementRandom : MonoBehaviour
{
    [SerializeField] private float minX, maxX;
    [SerializeField] private float minY, maxY;

    [SerializeField] private float moveSpeed = 8f;

    private Vector3 targetPosition;

    private float checkPosition = 0.1f;

    private void Start()
    {
        SetTargetPosition();
    }

    private void Update()
    { 
        Move();
    }

    private void SetTargetPosition()
    {
        targetPosition = new Vector3(Random.Range(minX, maxY), Random.Range(minY, maxY));
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            targetPosition, moveSpeed*Time.deltaTime);

        if (Vector3.Distance(transform.position,targetPosition)<checkPosition)
        {
            SetTargetPosition();
        }
    }
}
