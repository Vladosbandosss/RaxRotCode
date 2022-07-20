using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(TagManager.ENEMY_TAG)||col.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            Destroy(col.gameObject);
        }
    }
}
