using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy")||other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
