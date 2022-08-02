using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyBatV1 : MonoBehaviour
{
    [SerializeField] private float moveSpeedHorizontal = 2f, moveSpeedVertical = -2f;

    [SerializeField] private float horizontalMovementTreshold = 7f,verticalMovementTreshHold=4f;

    private float minX, maxX, minY, maxY;

    private Vector3 tempPos;

    private bool moveHorizontal = true;
    private bool moveVertical;

    private SpriteRenderer _sr;

    private void Awake()
    {
        minX = transform.position.x - horizontalMovementTreshold;
        maxX = transform.position.x + horizontalMovementTreshold;

        minY = transform.position.y - verticalMovementTreshHold;
        maxY = transform.position.y + verticalMovementTreshHold;

        moveVertical = Random.Range(0, 2) > 0 ? true : false;

        if (Random.Range(0,2)>0)
        {
            moveSpeedHorizontal *= -1f;
        }

        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleHorizontalMovement();
        
        HandleVerticalMovement();
    }

    private void HandleHorizontalMovement()
    {
        if (moveHorizontal)
        {
            tempPos = transform.position;
            tempPos.x += moveSpeedHorizontal * Time.deltaTime;

            if (tempPos.x>maxX)
            {
                moveSpeedHorizontal = -Mathf.Abs(moveSpeedHorizontal);
            }

            if (tempPos.x<minX)
            {
                moveSpeedHorizontal = Mathf.Abs(moveSpeedHorizontal);
            }

            transform.position = tempPos;

            if (moveSpeedHorizontal<0)
            {
                _sr.flipX = true;
            }else if (moveSpeedHorizontal>0)
            {
                _sr.flipX = false;
            }
        }
    }

    private void HandleVerticalMovement()
    {
        if (moveVertical)
        {
            tempPos = transform.position;
            tempPos.y += moveSpeedHorizontal * Time.deltaTime;
            
            if (tempPos.y>maxY)
            {
                moveSpeedVertical = -Mathf.Abs(moveSpeedVertical);
            }

            if (tempPos.y<minY)
            {
                moveSpeedVertical = Mathf.Abs(moveSpeedVertical);
            }

            transform.position = tempPos;
        }
    }
}
