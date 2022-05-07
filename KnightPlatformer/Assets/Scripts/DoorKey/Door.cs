using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Animator _anim;
    
    public static Door instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        _anim.Play(TagManager.OPENDOORANIM);
    }
}
