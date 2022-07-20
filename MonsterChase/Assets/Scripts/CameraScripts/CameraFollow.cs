using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;

    [SerializeField] private float minX = -60f, maxX = 60f;

    private void Start()
    {
        player = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void LateUpdate()
    {
        if (!player)
        {
            return;
        }
        
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x<minX)
        {
            tempPos.x = minX;
        }

        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }

        transform.position = tempPos;
    }
}
