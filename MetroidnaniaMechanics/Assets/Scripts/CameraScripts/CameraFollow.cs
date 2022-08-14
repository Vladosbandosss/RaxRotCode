using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    //private float YOffset = 5f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void LateUpdate()
    {
        if (!player)
        {
            return;
        }

        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
