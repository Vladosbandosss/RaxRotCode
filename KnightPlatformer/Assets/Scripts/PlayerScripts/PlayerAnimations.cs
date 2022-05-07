using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _sr = GetComponent<SpriteRenderer>();
    }

    public void PlayWalkAnim(int walk)
    {
        _animator.SetInteger(TagManager.WALKANIMATIONPARAM,walk);
    }

    public void ChangeFacingDirection(int direction)
    {
        if (direction > 0)
        {
            _sr.flipX = false;
        }else if (direction < 0)
        {
            _sr.flipX = true;
        }
    }

    public void PlayJumpAndFall(int jumpFall)
    {
        _animator.SetInteger(TagManager.JUMPANIMATIONPARAM,jumpFall);
    }
}
