using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableSpawner : MonoBehaviour
{
   [SerializeField] private GameObject collectable;

   [SerializeField] private float minX = -45f, maxX = 45f;
   private float positionToSpawn;

   private float minTimeToSpawn = 5f, maxTimeToSpawn = 25f;
   private float timeToSpawn;

   private Vector2 spawnPos;

   private void Start()
   {
      StartCoroutine("SpawnCollectables");
   }

   private IEnumerator SpawnCollectables()
   {
      timeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);

      yield return new WaitForSeconds(timeToSpawn);

      positionToSpawn = Random.Range(minX, maxX);

      spawnPos = new Vector2(positionToSpawn, transform.position.y);

      Instantiate(collectable, spawnPos, quaternion.identity);

      StartCoroutine("SpawnCollectables");
      
   }
}
