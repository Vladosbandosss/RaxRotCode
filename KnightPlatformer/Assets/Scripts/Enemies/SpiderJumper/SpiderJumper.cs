using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpiderJumper : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D rb;
    
    private float jumpForce;
    private float minJumpForce = 6f, maxJumpForce = 10f;

    private float jumperTime;

    private float minWaitTime = 2f, maxWaitTime = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        jumperTime = Time.time + Random.Range(minWaitTime,maxWaitTime);
    }

    private void Update()
    {
        if (Time.time > jumperTime)
        {
            Jump();
        }

        if (rb.velocity.y == 0f)
        {
            _anim.SetBool(TagManager.JUMPANIMATIONPARAM,false);
        }
    }

    private void Jump()
    {
        jumperTime = Time.time + Random.Range(minWaitTime,maxWaitTime);

        jumpForce = Random.Range(minJumpForce, maxJumpForce);

        rb.velocity = new Vector2(0f, jumpForce);
        
        _anim.SetBool(TagManager.JUMPANIMATIONPARAM,true);
    }
}
