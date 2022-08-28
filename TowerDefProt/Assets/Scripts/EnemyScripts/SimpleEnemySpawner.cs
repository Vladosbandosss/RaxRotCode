using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private Transform positionToSpawn;
    [SerializeField] private float timeBetweenSpawn = 2f;
    [SerializeField] private int amountToSpawn = 10;
    private bool canSpawn = true;

     public Castle _castle;
     public Path _path;

    private void Start()
    {
        StartCoroutine(nameof(Spawning));
    }

    private void SpawnEnemies()
    {
        if (canSpawn&&_castle.currentHealth>0)
        {
            Instantiate(enemyToSpawn, positionToSpawn.position, Quaternion.identity)
                .GetComponent<EnemyController>().SetUp(_castle,_path);
        }
        
        amountToSpawn--;

        if (amountToSpawn<=0)
        {
            canSpawn = false;
        }
    }

    private IEnumerator Spawning()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        SpawnEnemies();

        StartCoroutine(nameof(Spawning));
    }
}
