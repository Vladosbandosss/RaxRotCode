using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _anim;

    [SerializeField] private GameObject damageCollider;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void PlayAttackAnimation()
    {
        _anim.SetTrigger(TagManager.ATTACK_TRIGGER_PARAMETR);
    }

    public void PlayDeadAnimation()
    {
        _anim.SetBool(TagManager.DEATH_ANIMATION_PARAMETR,true);
    }

    public void ActivateDamageCollider()
    {
        damageCollider.SetActive(true);
    }

    public void DeactivateDamageCollider()
    {
        damageCollider.SetActive(false);
    }
}
