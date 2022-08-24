using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.PLAYER_TAG))
        {
           PlayerHealth.instance.HealPlayer();
           AudioManager.instance.PlayHealthPickUpMusic();
           Destroy(gameObject);
        }
    }
}
