using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    [SerializeField] private float minDamage = 5f;
    [SerializeField] private float maxDamage = 6f;

    private float projectileDamage;

    [SerializeField] private AudioClip spawnSound;

    [SerializeField] private GameObject boomEffect;

    [SerializeField] private AudioClip destroySound;

    [SerializeField] private bool isEnemy;

    private void Start()
    {
        projectileDamage =(int)Random.Range(minDamage, maxDamage);

        if (spawnSound)
        {
            AudioSource.PlayClipAtPoint(spawnSound,transform.position);
        }
    }

    private void Update()
    {
        if (isEnemy)
        {
            transform.Translate(0f,-speed*Time.deltaTime,0f);
        }
        else
        {
            transform.Translate(0f,speed*Time.deltaTime,0f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.PLAYER_TAG))
        {
           col.GetComponent<PlayerHealth>().TakeDamage(projectileDamage);
        }
        
        if (col.CompareTag(TagManager.ENEMY_TAG)||col.CompareTag(TagManager.METEOR_TAG))
        {
           col.GetComponent<EnemyHealth>().TakeDamage(projectileDamage,0f);
        }

        if (!col.CompareTag(TagManager.UNTAGGED_TAG)&&!col.CompareTag(TagManager.COLLECTABLE_TAG))
        {
           //ameObject.SetActive(false);
           Destroy(gameObject);
        }
        
        
    }
}
