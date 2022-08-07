using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.GROUND_TAG)||col.CompareTag(TagManager.TREE1_TAG)||col.CompareTag(TagManager.TREE2_TAG)||
            col.CompareTag(TagManager.OBSTACLE_TAG)||col.CompareTag(TagManager.ENEMY_TAG)||col.CompareTag(TagManager.HEALTH_TAG))
        {
            Destroy(col.gameObject);
        }
    }
}
