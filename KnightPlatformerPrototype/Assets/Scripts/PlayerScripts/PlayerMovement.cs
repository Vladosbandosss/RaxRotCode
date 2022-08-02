using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float moveSpeed = 5f;

    private float horizontalMovement;
    
    private PlayerAnimation _playerAnimation;

    [SerializeField] private float normalJumpForce = 4f;
    [SerializeField] private float doubleJumpForce = 5f;

    private float jumpForce;

    private RaycastHit2D groundCast;

    [SerializeField] private LayerMask groundMask;

    private bool canDoubleJump;
    private bool jumped;

    [SerializeField] private Transform groundCheck;

    private float checkJumpDistance = 0.1f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _playerAnimation = GetComponent<PlayerAnimation>();

        canDoubleJump = true;
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw(TagManager.HORIZONTAL_MOVEMENT_AXIS);
        
        HandleAnimation();
        
        HandleJumping();
        
        CheckDoubleJump();

        FromJumpToWalkOrIdle();
    }

    private void FixedUpdate()
    {
      Movement();   
    }

    private void Movement()
    {
        if (horizontalMovement>0)
        {
            _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);
        }else if (horizontalMovement<0)
        {
            _rb.velocity = new Vector2(-moveSpeed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(0f, _rb.velocity.y);
        }
    }

    private void HandleAnimation()
    {
        if (_rb.velocity.y==0f)
        {
            _playerAnimation.PlayWalk(Mathf.Abs((int)_rb.velocity.x));
        }
        
        _playerAnimation.ChangeFacingDirection((int)_rb.velocity.x);
        
        _playerAnimation.PlayJumpAndFall((int)_rb.velocity.y);
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                jumpForce = normalJumpForce;
                Jump();
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    jumpForce = doubleJumpForce;
                    Jump();
                }
            }
        }
    }

    bool IsGrounded()
    {
        groundCast = Physics2D.Raycast(groundCheck.position, Vector2.down, checkJumpDistance, groundMask);

        return groundCast;
    }

    private void Jump()
    {
        _rb.velocity = Vector2.up * jumpForce;
        jumped = true;
    }

    private void CheckDoubleJump()
    {
        if (!canDoubleJump&&_rb.velocity.y==0)
        {
            canDoubleJump = true;
        }
    }
    
    private void FromJumpToWalkOrIdle()
    {
        if (jumped&&_rb.velocity.y==0f)
        {
            jumped = false;

            if (Mathf.Abs((int)_rb.velocity.x)>0)
            {
                _playerAnimation.PlayAnimWithName(TagManager.WALK_ANIMATION);
            }
            else
            {
                _playerAnimation.PlayAnimWithName(TagManager.IDLE_INIMATION);
            }
        }
    }
    
}
