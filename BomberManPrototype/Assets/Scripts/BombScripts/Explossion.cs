using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Explossion : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 explodeDirection=Vector3.zero;
    private float explodeRange = 200f;
    private float explodeSpeed = 2f;

    private Vector3 startPosition;

    [SerializeField] private int damage = 1;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position,startPosition)>=explodeRange)
        {
            Destroy(gameObject);
        }
    }


    private void FixedUpdate()
    {
        _rb.velocity = explodeDirection * explodeSpeed * Time.deltaTime;
    }

    public void SetExplossion(Vector3 direction, float speed, float range)
    {
        explodeDirection = direction;
        explodeSpeed = speed;
        explodeRange = range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.PLAYER_TAG))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            print("vryv po igoku");
            Destroy(gameObject);
        }

        if (other.CompareTag(TagManager.ENEMY_TAG))
        {
            other.GetComponent<EnemyController>().Die();
            GameManager.instance.IncreaseScore();
            print("enemy");
        }

        if (other.CompareTag(TagManager.BLOCK_TAG))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag(TagManager.BOMB_TAG))
        {
            other.GetComponent<Bomb>().Explode();
        }

        if (other.CompareTag(TagManager.DESTACTABLE_BLOCK))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
