using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Breakable : MonoBehaviour
{

    [SerializeField] private GameObject boxFXDestroy;
    [SerializeField] private GameObject healthSpawn;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagManager.PLAYER_BULLET_TAG))
        {
            Instantiate(boxFXDestroy, transform.position, Quaternion.identity);
            AudioManager.instance.PlayBoxDestroyMusic();

            if (Random.Range(0,5)<2)
            {
                Instantiate(healthSpawn, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);
        }
    }
}
