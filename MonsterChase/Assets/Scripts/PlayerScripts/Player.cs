using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    
    private string WALKANIMATION = "Walk";

    private bool isGrounded;
    private string GROUNDTAG = "Ground";

    private string ENEMYTAG = "Enemy";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerMoveKeyBoard();
        
        AnimatePlayer();
        
        PlayerJump();
    }

    private void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    private void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALKANIMATION,true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALKANIMATION,true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALKANIMATION,false);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(GROUNDTAG))
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag(ENEMYTAG))
        {
            Destroy(gameObject);
        }
    }
}
