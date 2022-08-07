using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimWithTransitions : MonoBehaviour
{
    private Animator _anim;

    [SerializeField] private GameObject damageCollider;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void PlayFromJumpToRunning(bool running)
    {
        _anim.SetBool(TagManager.RUNNING_ANIMATION_PARAMETR,running);
    }

    public void PlayJump(float velocityY)
    {
        _anim.SetFloat(TagManager.JUMP_ANIMATION_PARAMETR,velocityY);
    }

    public void PlayDoubleJump()
    {
        _anim.SetTrigger(TagManager.DOUBLE_JUMP_ANIMATION_PARAMETR);
    }

    public void PlayAttack()
    {
        _anim.SetTrigger(TagManager.ATTACK_ANIMATION_PARAMETR);
    }

    public void PlayJumpAttack()
    {
        _anim.SetTrigger(TagManager.JUMP_ATTACK_ANIMATION_PARAMETR);
    }

    public void ActivateDamageDetector()
    {
        damageCollider.SetActive(true);
    }

    public void DeactivateDamageCollider()
    {
        damageCollider.SetActive(false);
    }
}
