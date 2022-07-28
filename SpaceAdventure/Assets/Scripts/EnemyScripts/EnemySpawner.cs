using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField] private GameObject[] enemies;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float spawnWaitTime = 2f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnWave(spawnWaitTime));
    }

    private void SpawnNewWaveOfEnemies()
    {
        if (spawnedEnemies.Count > 0)
        {
            return;
        }

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randIndex = Random.Range(0, enemies.Length);
            GameObject newEnemy = 
                Instantiate(enemies[randIndex], spawnPoints[i].position, Quaternion.identity);
            
            spawnedEnemies.Add(newEnemy);
        }
        
       GamePlayUIController.instance.SetInfo(1);
        
    }
    private IEnumerator SpawnWave(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SpawnNewWaveOfEnemies();
    }

    public void CheckToSpawnNewWaves(GameObject shipToRemove)
    {
        spawnedEnemies.Remove(shipToRemove);

        if (spawnedEnemies.Count==0)
        {
            StartCoroutine(SpawnWave(spawnWaitTime));
        }
    }
}
