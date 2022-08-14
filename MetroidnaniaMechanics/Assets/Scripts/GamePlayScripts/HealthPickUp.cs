using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
 
    private int healAmmount = 1;
    [SerializeField] private GameObject pickUpFx;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.PLAYER_TAG))
        {
           col.GetComponent<PalyerHealth>().HealPlayer(healAmmount);
           Instantiate(pickUpFx, transform.position, Quaternion.identity);
           
           Destroy(gameObject);
        }
    }
}
