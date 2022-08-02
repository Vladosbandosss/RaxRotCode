using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public static Lock instance;

    private Animator _anim;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }

        _anim = GetComponent<Animator>();
    }

    public void PlayOpenAnim()
    {
        _anim.Play(TagManager.OPEN_DOOR_ANIMATION);
    }
    
    
}
