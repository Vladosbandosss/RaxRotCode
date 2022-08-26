using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform playerToFollow;
    private Vector3 temp;

    private void Awake()
    {
        playerToFollow = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        temp = playerToFollow.position;
        temp.z = transform.position.z;
        transform.position = temp;
    }
}
