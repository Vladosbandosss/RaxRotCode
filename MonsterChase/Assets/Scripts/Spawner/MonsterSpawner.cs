using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterReference;
    private GameObject spawnedMonster;
    
    [SerializeField] private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    private float minTimeForSpawn = 1f, maxTimeForSpawn = 5f;
    private float minEnemySpeed = 4f, maxEnemySpeed = 10f;

    private bool canSpawned = true;

    private void Start()
    {
        StartCoroutine("SpawnMonsters");
    }

    private IEnumerator SpawnMonsters()
    {
        while (canSpawned)
        {
            yield return new WaitForSeconds(Random.Range(minTimeForSpawn, maxTimeForSpawn));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide==0)//left
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(minEnemySpeed, maxEnemySpeed);
            }
            else //right
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(-minEnemySpeed, -maxEnemySpeed);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
       
    }


}
