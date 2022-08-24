using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    private bool canDamagePlayer = true;
    private float timeToReset = 3f;
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.PLAYER_TAG)&&canDamagePlayer)
        {
            canDamagePlayer = false;
            StartCoroutine("ResetDamage");
            PlayerHealth.instance.DamagePlayer();
        }
    }

    private IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(timeToReset);
        canDamagePlayer = true;
    }
}
