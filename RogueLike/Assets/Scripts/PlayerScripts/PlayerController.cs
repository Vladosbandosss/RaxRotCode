using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
     private Rigidbody2D rb;

     [SerializeField] private float moveSpeed = 3f;

     private Vector2 moveInput;

     [SerializeField] private Transform gunArm;

     private Camera _camera;

     [SerializeField] private GameObject bulletToFire;
     [SerializeField] private Transform firePoint;

     private float timer;
     private float timeBetweenShoots = 0.5f;

     private bool isPlayerEneble;

     private bool _canMove = true;

     public bool CanMove
     {
         get { return _canMove; }
         set { _canMove = value; }
     }
     
     private void Awake()
     {
         rb = GetComponent<Rigidbody2D>();

         _camera=Camera.main;

         if (instance==null)
         {
             instance = this;
         }
     }

     private void Update()
     {
         if (_canMove)
         {
             PlayerMovement();
         }
         else
         {
             rb.velocity=Vector2.zero;
         }
     }

     private void PlayerMovement()
     {
         moveInput.x = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS);
         moveInput.y = Input.GetAxisRaw(TagManager.VERTICAL_AXIS);
         moveInput.Normalize();

         rb.velocity = moveInput * moveSpeed;

         Vector3 mousePosition = Input.mousePosition;
         Vector3 screenPoint = _camera.WorldToScreenPoint(transform.localPosition);

         if (mousePosition.x<screenPoint.x)
         {
             transform.localScale = new Vector3(-1f, 1f, 1f);
             gunArm.localScale = new Vector3(-1f, -1f, 1f);
         }
         else
         {
             transform.localScale = Vector3.one;
             gunArm.localScale = Vector3.one;
         }
         
         Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
         float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
         gunArm.rotation=Quaternion.Euler(0,0,angle);

         if (Input.GetMouseButtonDown(0))
         {
             Shoot();
         }
     }

     private void Shoot()
     {
         if (Time.time>timer)
         {
             Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
             AudioManager.instance.PlayPlayerShootMusic();
             timer = Time.time + timeBetweenShoots;
         }
     }
     
}
