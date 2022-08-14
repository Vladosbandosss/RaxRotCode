using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _anim;

    private Transform playerTarget;
    private float checkToOpen = 5f;

    private void Awake()
    {
        _anim = GetComponent<Animator>();

        playerTarget = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void Update()
    {
        if (!playerTarget)
        {
            return;
        }
        
        CheckDoor();
    }

    private void CheckDoor()
    {
        if (Vector3.Distance(transform.position,playerTarget.position)<checkToOpen)
        {
            _anim.SetBool(TagManager.DOOR_OPEN_PARAMETR,true);
        }
        else
        {
            _anim.SetBool(TagManager.DOOR_OPEN_PARAMETR,false);
        }
    }
}
