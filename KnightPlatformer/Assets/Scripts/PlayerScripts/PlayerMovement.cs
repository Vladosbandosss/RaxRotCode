using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 5f;

    private float horizontalMovement;

    private Vector3 movePos;

    private PlayerAnimations _playerAnimations;

    [SerializeField] private float normalJumpForce = 5f, doubleJumpForce = 6f;

    private float jumpForce = 5f;

    private RaycastHit2D grounfCast;
    private CapsuleCollider2D capsuleColl;

    [SerializeField] private LayerMask groundMask;

    private bool canDoubleJump;
    private bool jumped;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        _playerAnimations = GetComponent<PlayerAnimations>();

        capsuleColl = GetComponent<CapsuleCollider2D>();

        canDoubleJump = true;
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw(TagManager.HORIZONATALAXIS);
        
        HandleAnimation();
        
        HandleJumping();
        
        CheckDoubleJump();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (horizontalMovement > 0)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (horizontalMovement < 0)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    private void HandleAnimation()
    {
        if (rb.velocity.y == 0)
        {
            _playerAnimations.PlayWalkAnim(Mathf.Abs((int)rb.velocity.x));
        }
        
        _playerAnimations.ChangeFacingDirection((int)rb.velocity.x);
        
        _playerAnimations.PlayJumpAndFall((int)rb.velocity.y);
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded())
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

    private bool isGrounded()
    {
        grounfCast = Physics2D.Raycast(capsuleColl.bounds.center,
            Vector2.down, capsuleColl.bounds.extents.y + 0.01f, groundMask);

        return grounfCast.collider != null;
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        jumped = true;
    }

    private void CheckDoubleJump()
    {
        if (!canDoubleJump && rb.velocity.y == 0f)
        {
            canDoubleJump = true;
        }
    }
}
