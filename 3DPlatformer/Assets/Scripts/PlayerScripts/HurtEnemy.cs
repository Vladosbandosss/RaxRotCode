using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.ENEMY_TAG))
        {
            other.GetComponent<EnemyHealth>().TakeDamage();
        }
    }
}
