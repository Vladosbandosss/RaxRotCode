using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
   [SerializeField] private GameObject spikePrefab, swingingPrefab, wolfPrefab;
   [SerializeField] private GameObject[] rotatingObstacles;

   private float spikeYpos = -3.5f;
   private float wolfYpos = -3.1f;
   private float rotatingObstacleMinY = -3.4f, rotatingObstacleMaxY = -0.5f;
   private float swingObstacleMinY = 0.7f, swingObstacleMaxY = 3f;

   private float minSpawnWaitTime = 2f, maxSpawnWaitTime = 3.5f;
   private float spawnWaitTime;

   private int obstacleTypesCount = 4;
   private int obstacleToSpawn;

   private Camera mainCam;
   private float offsetObstacle = 20f;
   
   private Vector3 obstacleSpawnPos=Vector3.zero;

   private GameObject newObstacle;

   [SerializeField] private GameObject healthPrefab;
   private float minHealthY = -3.3f, maxHealthY = 1f;
   private Vector3 healthSpawnPos;
   private float offsetHealth = 30f;

   private void Awake()
   {
      mainCam=Camera.main;
   }

   private void Update()
   {
      HandleObstacleSpawning();
      
   }

   private void HandleObstacleSpawning()
   {
      if (Time.time>spawnWaitTime)
      {
         spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);
         
         SpawnObstacle();
         
         SpawnHealth();
      }
   }

   private void SpawnObstacle()
   {
      obstacleToSpawn = Random.Range(0, obstacleTypesCount);

      obstacleSpawnPos.x = mainCam.transform.position.x + offsetObstacle;

      switch (obstacleToSpawn)
      {
         case 0:
            newObstacle = Instantiate(spikePrefab);
            obstacleSpawnPos.y = spikeYpos;
            break;
         case 1:
            newObstacle = Instantiate(swingingPrefab);
            obstacleSpawnPos.y = Random.Range(swingObstacleMinY,swingObstacleMaxY);
            break;
         case 2:
            newObstacle = Instantiate(wolfPrefab);
            obstacleSpawnPos.y = wolfYpos;
            break;
         case 3:
            newObstacle = Instantiate(rotatingObstacles[Random.Range(0,rotatingObstacles.Length)]);
            obstacleSpawnPos.y = Random.Range(rotatingObstacleMinY,rotatingObstacleMaxY);
            break;
      }

      newObstacle.transform.position = obstacleSpawnPos;
   }

   private void SpawnHealth()
   {
      if (Random.Range(0,10)>6)
      {
         healthSpawnPos.x = mainCam.transform.position.x + offsetHealth;
         healthSpawnPos.y = Random.Range(minHealthY, maxHealthY);
         Instantiate(healthPrefab, healthSpawnPos, Quaternion.identity);
      }
   }
   
}
