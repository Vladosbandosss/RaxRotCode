using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
     private float bulletSpeed = 10f;

    private Rigidbody2D rb;
    
    //public Vector2 moveDirection;

    [SerializeField] private GameObject ShootFX;

    private int damageAmount = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        rb.velocity = new Vector2(bulletSpeed, 0f);
    }

    public void SetSpeed(float speed)
    {
        bulletSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag(TagManager.ENEMY_TAG))
        {
           col.GetComponent<EnemyHealth>().DamageEnemy(damageAmount);
        }
        Instantiate(ShootFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
       
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
