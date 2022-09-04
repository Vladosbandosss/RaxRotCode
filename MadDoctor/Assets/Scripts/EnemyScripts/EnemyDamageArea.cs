using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{

    [SerializeField] private float damage = 10f;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.PLAYER_TAG))
        {
           col.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
