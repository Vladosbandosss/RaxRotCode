using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoving : MonoBehaviour
{
    [SerializeField] private float blockMovingSpeed = 1f;
    private bool moveForward = true;

    [SerializeField] private float minZPosition = 4f, maxZPosition = 14f;

    private void Update()
    {
        MoveBlock();
    }

    private void MoveBlock()
    {
        if (moveForward)
        {
            transform.position += new Vector3(0f, 0f, blockMovingSpeed * Time.deltaTime);
            if (transform.position.z>=maxZPosition)
            {
                moveForward = !moveForward;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, 0f, blockMovingSpeed * Time.deltaTime);
            if (transform.position.z<=minZPosition)
            {
                moveForward = !moveForward;
            }
        }
    }
}
