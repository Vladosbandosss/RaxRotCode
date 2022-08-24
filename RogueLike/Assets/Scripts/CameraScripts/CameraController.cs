using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;

     private  Transform target;

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
        transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(target.position.x, target.position.y, transform.position.z),moveSpeed*Time.deltaTime);
        
        
    }
    
}
