using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector3 moveDirection;

    private void Start()
    {
        moveDirection = PlayerController.instance.transform.position - transform.position;
        moveDirection.Normalize();
    }

    private void Update()
    {
        transform.position += moveDirection * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.PLAYER_TAG))
        {
            PlayerHealth.instance.DamagePlayer();
        }
        
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
