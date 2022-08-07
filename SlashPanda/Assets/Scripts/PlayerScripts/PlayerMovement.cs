using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f, jumpForce = 20f;

    private Rigidbody2D _rb;

    private Transform groundCheckPos;

    [SerializeField] private LayerMask groundLayer;

    private bool canDoubleJump;

    private PlayerAnimWithTransitions _playerAnim;

    [SerializeField] private float attackWaitTime = 0.5f;
    private float attackTimer;
    private bool canAttack;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        groundCheckPos = transform.GetChild(0).transform;

        _playerAnim = GetComponent<PlayerAnimWithTransitions>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        PlayerJump();
        
        AnimatePlayer();
        
        GetAttackInput();
        
        HandleAttackAction();
    }

    private void MovePlayer()
    {
        _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(groundCheckPos.position, Vector2.down, 0.1f, groundLayer);
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsGrounded()&&canDoubleJump)
            {
                canDoubleJump = false;
                _rb.velocity=Vector2.zero;
                _rb.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
                
                _playerAnim.PlayDoubleJump();
            }
            if (IsGrounded())
            {
                canDoubleJump = true;
                _rb.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
            }
        }
    }

    private void AnimatePlayer()
    {
        _playerAnim.PlayJump(_rb.velocity.y);
        _playerAnim.PlayFromJumpToRunning(IsGrounded());
    }

    private void GetAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Time.time>attackTimer)
            {
                attackTimer = Time.time + attackWaitTime;
                canAttack = true;
            }
        }
    }

    private void HandleAttackAction()
    {
        if (canAttack&&IsGrounded())
        {
            canAttack = false;
            _playerAnim.PlayAttack();
        }else if (canAttack&&!IsGrounded())
        {
            canAttack = false;
            _playerAnim.PlayJumpAttack();
        }
    }
}
