using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    [SerializeField] private float moveSpeed=5f;
    [SerializeField] private float jumpForce=10f;

    private Vector3 moveDirection;
    private float Xaxis, Zaxis;
    private float yStore;
    [SerializeField] private float addGravity = 5f;
    private float normalizeYdirection = -1f;

    private CharacterController _characterController;

     private Camera cam;
     [SerializeField] private GameObject playerModel;

     [SerializeField] private Animator _anim;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        
        _characterController = GetComponent<CharacterController>();
        cam=Camera.main;
    }

    private void Update()
    {
        Movement();
        
        TurnPlayer();
        
        PlayerAnimation();
    }

    private void Movement()
    {
        yStore = moveDirection.y;
        
        Xaxis = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS);
        Zaxis = Input.GetAxisRaw(TagManager.VERTICAL_AXIS);
        
        moveDirection = transform.forward * Zaxis+transform.right*Xaxis;
        moveDirection = moveDirection.normalized;
        moveDirection *= moveSpeed;
        moveDirection.y = yStore;

        if (_characterController.isGrounded)
        {
            moveDirection.y = normalizeYdirection;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }
        
        moveDirection.y += Physics.gravity.y * Time.deltaTime * addGravity;
        
        _characterController.Move(moveDirection*Time.deltaTime);
    }

    private void TurnPlayer()
    {
        if (Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS)!=0||Input.GetAxisRaw(TagManager.VERTICAL_AXIS)!=0)
        {
            transform.rotation=Quaternion.Euler(0f,cam.transform.rotation.eulerAngles.y,0f);
        }
    }

    private void PlayerAnimation()
    {
        _anim.SetFloat(TagManager.PLAYER_RUN_ANIMATION_PARAMETR, Mathf.Abs(moveDirection.z+moveDirection.x));
        _anim.SetBool(TagManager.PLAYER_JUMP_GROUNDED_ANIMATION_PARAMETR,_characterController.isGrounded);
    }
    
}
