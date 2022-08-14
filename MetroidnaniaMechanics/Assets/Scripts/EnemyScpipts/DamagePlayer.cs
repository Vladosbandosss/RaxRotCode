using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private int damageAmount=1;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            col.gameObject.GetComponent<PalyerHealth>().DamagePlayer(damageAmount);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.PLAYER_TAG))
        {
            col.GetComponent<PalyerHealth>().DamagePlayer(damageAmount);
        }
    }
}
