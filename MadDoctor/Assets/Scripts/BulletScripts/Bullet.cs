using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;

    [SerializeField] private float damageAmount = 35f;

    private Vector3 moveVector=Vector3.zero;
    
    private void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        moveVector.x = moveSpeed * Time.deltaTime;
        transform.position += moveVector;
    }

    public void SetNegativeSpeed()
    {
        moveSpeed *= -1f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.ENEMY_TAG))
        {
            col.GetComponent<EnemyHealthScripts>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}