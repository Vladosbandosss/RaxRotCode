using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private bool deactivateGameObject;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.PLAYER_TAG))
        {
            col.GetComponent<PlayerHealth>().SubstractHealth();
            if (deactivateGameObject)
            {
                gameObject.SetActive(false);
            }
        }

        if (col.CompareTag(TagManager.ENEMY_TAG)||col.CompareTag(TagManager.OBSTACLE_TAG))
        {
           col.GetComponent<EnemyHealth>().TakeDamage();
        }
    }
}
