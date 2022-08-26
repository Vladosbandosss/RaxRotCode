using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float torgValue = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(torgValue);
        }else if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-torgValue);
        }
    }
    
}
