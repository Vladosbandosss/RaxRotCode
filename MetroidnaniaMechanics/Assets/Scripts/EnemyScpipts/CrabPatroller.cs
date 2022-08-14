using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabPatroller : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    private int currentPoint;

    [SerializeField] private float moveSpeed, waitAtPoints;
    private float waitCounter;

    [SerializeField] private float jumpForce;

    private float prevPosition;

    private SpriteRenderer sr;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        
        waitCounter = waitAtPoints;
    }
    
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position,
            moveSpeed * Time.deltaTime);
        
       
        
        if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 0.1f)
        {
            currentPoint++;

            if (currentPoint>=patrolPoints.Length)
            {
                currentPoint = 0;
            }
            
            prevPosition = transform.position.x;
        }
        
        ChangFacingDirection();
    }

    private void ChangFacingDirection()
    {
        if (transform.position.x>prevPosition)
        {
            sr.flipX = true;
        }else if (transform.position.x<prevPosition)
        {
            sr.flipX = false;
        }
    }
    
    
}
