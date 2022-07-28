using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform[] spawnLaserPosition;
    [SerializeField] private Transform spawnBlasterPosition;

    [SerializeField] private bool laserShooter;

    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject blaster;

    private float minTimeToShoot = 3f, maximeToShoot = 8f;
    private float timeToShoot;

    [HideInInspector] public bool isEnemyAlive;

    private void Start()
    {
        isEnemyAlive = true;

        StartCoroutine("ShootPlayer");
    }

    private IEnumerator ShootPlayer()
    {
        while (isEnemyAlive)
        {
            timeToShoot = Random.Range(minTimeToShoot, maximeToShoot);

            yield return new WaitForSeconds(timeToShoot);

            if (laserShooter)
            {
                Instantiate(laser, spawnLaserPosition[0].position, Quaternion.identity);
                Instantiate(laser, spawnLaserPosition[1].position, Quaternion.identity);
            }
            else
            {
                Instantiate(blaster, spawnBlasterPosition.position, Quaternion.identity);
            }
        }
        
    }
    
    
}
