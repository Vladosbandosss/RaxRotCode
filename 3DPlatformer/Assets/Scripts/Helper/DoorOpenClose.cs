using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    public static DoorOpenClose instance;
    
    private Animator _animator;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        
        _animator = GetComponent<Animator>();
    }
    
    public void OpenDoor()
    {
        _animator.Play(TagManager.OPEN_DOOR_ANIMATION);
    }
}
