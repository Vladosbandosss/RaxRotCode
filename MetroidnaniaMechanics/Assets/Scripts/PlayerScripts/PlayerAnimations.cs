using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _anim;
    private Transform temScale;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void AnimPlayerMovement(float playerSpeed)
    {
        _anim.SetFloat(TagManager.PLAYER_MOVE_PARAMETR,playerSpeed);
    }

    public void AnimPlayerJump(bool isOnGround)
    {
        _anim.SetBool(TagManager.PLAYER_JUMP_PARAMETR,isOnGround);
    }

    public void ChangeFacingDirection(float direction)
    {
        if (direction>0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }else if (direction<0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        
    }

    public void PlayShootAnimation()
    {
        _anim.SetTrigger(TagManager.PLAYER_SHOOT_TRIGGER);
    }

    public void AnimDoublePlayerJump()
    {
        _anim.SetTrigger(TagManager.PLAYER_DOUBLE_JUMP);
    }
}
