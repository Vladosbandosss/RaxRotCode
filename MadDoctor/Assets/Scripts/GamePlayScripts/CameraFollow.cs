using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTarget;

    [SerializeField] private float smothSpeed = 2f;

    private float playerBoundMinX = -65f, playerBoundMaxX = 65f;

    private Vector3 tempPosition;

    private void Awake()
    {
        playerTarget = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void Update()
    {
        if (!playerTarget)
        {
            return;
        }

        tempPosition = transform.position;

        tempPosition = Vector3.Lerp(transform.position,
            new Vector3(playerTarget.position.x, transform.position.y, transform.position.z),
            smothSpeed * Time.deltaTime);

        if (tempPosition.x>playerBoundMaxX)
        {
            tempPosition.x = playerBoundMaxX;
        }

        if (tempPosition.x<playerBoundMinX)
        {
            tempPosition.x = playerBoundMinX;
        }

        transform.position = tempPosition;
    }
}
