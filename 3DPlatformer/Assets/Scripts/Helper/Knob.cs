using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour
{
    private Animator anim;
    private bool isStand;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.PLAYER_TAG))
        {
            isStand = true;
            anim.SetBool(TagManager.STANDING_ON_KNOB,isStand);
            DoorOpenClose.instance.OpenDoor();
        }
    }
}
