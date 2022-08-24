using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float speed = 7.5f;

    [SerializeField] private GameObject impactFX;

    [SerializeField] private int damage = 1;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = transform.right*speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.ENEMY_TAG))
        {
            col.GetComponent<EnemyController>().TakeDamage(damage);
            col.GetComponent<EnemyController>().Chace = true;
        }
        
        Instantiate(impactFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
