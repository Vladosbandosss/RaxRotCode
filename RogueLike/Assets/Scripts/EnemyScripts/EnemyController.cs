using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator _anim;
    
    [SerializeField] private float moveSpeed = 3f;

    [SerializeField] private float rangeToChase = 8f;
    private Vector3 moveDirection;

    [SerializeField] private int health=5;

    [SerializeField] private GameObject [] deadSplatters;
    [SerializeField] private GameObject enemyHurtFX;

    [SerializeField] private bool shouldShoot;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;

    private float timerToRespawn = 3f;
    private float timer;

    private bool chase; 
    public bool Chace
    {
        get { return chase; }
        set { chase=value; }
    }

    private Vector3 tempScale;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        
        if (Vector3.Distance(transform.position,PlayerController.instance.transform.position)<rangeToChase)
        {
            chase = true;
            shouldShoot = true;
        }
        
        if (chase&&PlayerController.instance.gameObject.activeInHierarchy)
        {
            moveDirection = PlayerController.instance.transform.position - transform.position;
            _anim.SetBool(TagManager.SKELETON_MOVE_PARAMETR,true);
        }
        else
        {
            moveDirection = Vector3.zero;
            _anim.SetBool(TagManager.SKELETON_MOVE_PARAMETR,false);
        }
        
        moveDirection.Normalize();

        rb.velocity = moveDirection * moveSpeed;

        if (shouldShoot&&PlayerController.instance.gameObject.activeInHierarchy)
        {
            if (Time.time>timer)
            {
                Instantiate(bullet, firePoint.position, Quaternion.identity);
                timer = Time.time + timerToRespawn;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(enemyHurtFX, transform.position, Quaternion.identity);

        if (health<=0)
        {
            int indexToSpawn = Random.Range(0, deadSplatters.Length);
            Instantiate(deadSplatters[indexToSpawn], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
    
    
}
