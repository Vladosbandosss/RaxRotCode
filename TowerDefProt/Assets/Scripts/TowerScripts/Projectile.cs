using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float moveSpeed = 7f;

    [SerializeField] private float canonBallLifeTime = 5f;

    [SerializeField] private GameObject impactFX;

    [SerializeField] private float damage = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rb.velocity = transform.forward * moveSpeed;
        
        Invoke("DestroyObject",canonBallLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.ENEMY_TAG))
        {
            Instantiate(impactFX, transform.position, Quaternion.identity);
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
