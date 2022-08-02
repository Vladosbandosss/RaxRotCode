using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyBatV2 : MonoBehaviour
{
    [SerializeField] private float minX = -8f, maxX = 8f, minY=4.5f, maxY=4.5f;

    private Vector3 targetPosition;

    [SerializeField] private float moveSpeed = 2f;

    private SpriteRenderer _sr;
    private float previousXPos;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MoveToTargetPos();
    }

    private void MoveToTargetPos()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
            previousXPos = transform.position.x;
        }
        
        ChangeFacingDirection();
    }

    private void ChangeFacingDirection()
    {
        if (transform.position.x>previousXPos)
        {
            _sr.flipX = false;
        }else if (transform.position.x<previousXPos)
        {
            _sr.flipX = true;
        }
    }
}
