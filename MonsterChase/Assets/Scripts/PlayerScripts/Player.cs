using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _sr;
    
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 11f;

    private float movementX;

    private bool isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    private void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2(movementX * moveForce, _rb.velocity.y);
    }

    private void AnimatePlayer()
    {
        if (movementX>0)
        { 
            _anim.SetBool(TagManager.WALK_ANIMATION,true);
            _sr.flipX = false;
        }else if (movementX < 0)
        {
            _anim.SetBool(TagManager.WALK_ANIMATION,true);
            _sr.flipX = true;
        }
        else
        {
            _anim.SetBool(TagManager.WALK_ANIMATION,false);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            isGrounded = false;
            _rb.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(TagManager.GROUND_TAG))
        {
            isGrounded = true;
        }

        if (col.gameObject.CompareTag(TagManager.ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
