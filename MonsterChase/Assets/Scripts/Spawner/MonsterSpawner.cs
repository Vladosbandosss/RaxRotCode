using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterRef;

    [SerializeField] private Transform leftPos, rightPos;

    private GameObject spawnedMonster;

    private int randomMonsterIndex, randomSpawnSide;

    private int minSpawnTime = 1, maxSpawnTime = 5;

    private void Start()
    {
        StartCoroutine(nameof(SpawnMonsters));
    }

    private IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            randomMonsterIndex = Random.Range(0, monsterRef.Length);
            randomSpawnSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterRef[randomMonsterIndex]);

            if (randomSpawnSide == 0)//left
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else//right
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(-10,-4);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
