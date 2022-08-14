using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpForce = 20f;

    private float xAxis;

    [SerializeField] private Transform groundPoint;
    private bool isOnGround;
    private float groundCheckRadius = 0.15f;

    [SerializeField] private LayerMask groundLayer;

    private PlayerAnimations _playerAnimations;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    private GameObject newBullet;
    private float bulletSpeed = 10f;
    
    private bool canDoubleJump;

    [SerializeField] private float dashSpeed=25f, dashTime=0.2f;
    private float dashCounter;

    [SerializeField] private SpriteRenderer sr, afterImage;
    [SerializeField] private float afterImageLifeTime, timeBetweenAfterImages;
    private float afterImageCounter;
    [SerializeField] private Color afterImageColor;

    [SerializeField] private GameObject standing, ball;
    [SerializeField] private float waitToBall;
     private float ballCounter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        _playerAnimations = GetComponent<PlayerAnimations>();

        canDoubleJump = true;
    }
    

    private void Update()
    {
        Movement();
        
        Jump();

        ISgrounded();
        
        AnimatePlayer();
        
        Shoot();

        ISgrounded();
        
        MakeDash();
        
      // TransformToBall();

    }

    private void Movement()
    {
        xAxis = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS);
        rb.velocity = new Vector2(xAxis * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }else if (canDoubleJump&&Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            _playerAnimations.AnimDoublePlayerJump();
            canDoubleJump = false;
        }

        if (isOnGround)
        {
            canDoubleJump = true;
        }
        
    }

    private bool ISgrounded()
    {
        return isOnGround = Physics2D.OverlapCircle(groundPoint.position, groundCheckRadius, groundLayer);
    }

    private void AnimatePlayer()
    {
        _playerAnimations.AnimPlayerMovement(Mathf.Abs(rb.velocity.x));
        
        _playerAnimations.AnimPlayerJump(ISgrounded());
        
        _playerAnimations.ChangeFacingDirection(rb.velocity.x);
    }

    private void Shoot()
    {
        if (Input.GetButtonDown(TagManager.LEFT_MOUSE_BUTTON))
        { 
            newBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);

            if (transform.localScale.x==1)
            {
                newBullet.GetComponent<BulletController>().SetSpeed(bulletSpeed);
            }
            else
            {
                newBullet.GetComponent<BulletController>().SetSpeed(-bulletSpeed);
            }
            
            _playerAnimations.PlayShootAnimation();
        }
    }

    private void MakeDash()
    {
        if (!standing.activeSelf)
        {
            return;
        }
        
        if (Input.GetButtonDown(TagManager.RIGHT_MOUSE_BUTTON)&&isOnGround&&Mathf.Abs(rb.velocity.x)>0)
        {
            dashCounter = dashTime;
            
            ShowAfterImage();
            
        }

        if (dashCounter>0&&Mathf.Abs(rb.velocity.x)>0)
        {
            dashCounter -= Time.deltaTime;

            rb.velocity = new Vector2(dashSpeed * transform.localScale.x, rb.velocity.y);
            
        }
    }

    private void ShowAfterImage()
    {
        SpriteRenderer image = Instantiate(afterImage, transform.position, transform.rotation);
        image.sprite = sr.sprite;
        image.transform.localScale = transform.localScale;
        image.color = afterImageColor;
        Destroy(image.gameObject,afterImageLifeTime);
    }

    private void TransformToBall()
    {
        if (!ball.activeSelf)
        {
            if (Input.GetAxisRaw(TagManager.VERTICAL_AXIS)<-0.9f)
            {
                ballCounter -= Time.deltaTime;
                if (ballCounter<=0)
                {
                    ball.SetActive(true);
                    standing.SetActive(false);
                }
            }
            else
            {
                ballCounter = waitToBall;
            }
        }
    }
}
