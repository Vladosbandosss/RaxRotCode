using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Vector3 temp;
    private void Awake()
    {
        target = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void LateUpdate()
    {
        if (!target)
        {
            return;
        }
        
        //FollowTarget();
    }

    private void FollowTarget()
    {
        temp = transform.position;
        temp.x = target.position.x;
        temp.z = target.position.z;
        transform.position = temp;
    }
}

