using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField] private GameObject enemyPrefab;

    private GameObject newEnemy;

    [SerializeField] private Transform[] spawnPosition;

    [SerializeField] private int enemySpawnLimit = 10;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    [SerializeField] private float minSPawnTime = 2f, maxSpawnTime = 4f;
    private float spawnTime;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Invoke("SpawnEnemy",Random.Range(minSPawnTime,maxSpawnTime));
    }

    private void SpawnEnemy()
    {
        
        if (spawnedEnemies.Count==enemySpawnLimit)
        {
            return;
        }

        newEnemy = Instantiate(enemyPrefab, spawnPosition[Random.Range(0, spawnPosition.Length)].position,
            Quaternion.identity);
        
        spawnedEnemies.Add(newEnemy);
        
        Invoke("SpawnEnemy",Random.Range(minSPawnTime,maxSpawnTime));
    }

    public void EnemyDied(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);
        
        Invoke("SpawnEnemy",Random.Range(minSPawnTime,maxSpawnTime));
    }
}
