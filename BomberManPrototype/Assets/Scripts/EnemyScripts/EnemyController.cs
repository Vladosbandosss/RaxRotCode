using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private Transform [] target;
    private int index;
    private float distanceToChange = 0.1f;
    [SerializeField] private float moveSpeed = 1f;
    private Vector3 moveToTarget;

    private bool isMoving = true;
    private bool movingForward = true;

    private int enemyDamage = 100;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        if (isMoving)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        moveToTarget = Vector3.MoveTowards(transform.position, target[index].position, moveSpeed*Time.deltaTime);
        _rb.MovePosition(moveToTarget);

        if (Vector3.Distance(transform.position,target[index].position)<distanceToChange)
        {
            if (movingForward)
            { 
                if (index>=target.Length-1)
                {
                    movingForward = false;
                    index--;
                }
                else
                {
                    index++;
                }
            }
            else
            {
                if (index<=0)
                {
                    movingForward = true;
                    index++;
                }
                else
                {
                    index--;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }

        if (collision.gameObject.CompareTag(TagManager.BOMB_TAG))
        {
            print("Bomb");
            
            if (movingForward)
            {
                index--;
            }
            else
            {
                index++;
            }
            movingForward = !movingForward;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
