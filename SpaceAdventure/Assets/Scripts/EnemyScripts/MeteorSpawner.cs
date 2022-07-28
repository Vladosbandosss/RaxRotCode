using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteors;

    [SerializeField] private float minX, maxX;

    private float minSpawnInterval = 4f, maxSpawnInterval = 10f;

    private int randSpawnNumber;

    private Vector3 ranSpawnPos;

    private int minSpawnNumber = 1;
    
    private void Start()
    {
        
      InvokeRepeating("SpawnMeteors",
          Random.Range(minSpawnInterval,maxSpawnInterval),Random.Range(minSpawnInterval,maxSpawnInterval));
    }

    private void SpawnMeteors()
    {
        randSpawnNumber = Random.Range(minSpawnNumber, meteors.Length);

        for (int i = 0; i < randSpawnNumber; i++)
        {
            ranSpawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            Instantiate(meteors[Random.Range(0, meteors.Length)], ranSpawnPos, Quaternion.identity);
        }
    }
}
