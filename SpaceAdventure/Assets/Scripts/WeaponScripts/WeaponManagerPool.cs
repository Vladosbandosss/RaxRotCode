using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class WeaponManagerPool : MonoBehaviour
{
    [SerializeField] private GameObject projectile; 
    private List<GameObject> projectilePool = new List<GameObject>();
    
    private GameObject projectileHolder;

    [SerializeField] private KeyCode keyToPressToShoot;

    private bool projectileSpawned;

    [SerializeField] private Transform projectileSpawnPoint;

    [SerializeField] private float shootWaitTime = 0.2f;

    private float shootTimer;

    private bool canShoot;

    [SerializeField] private bool isEnemy;

    private void Awake()
    {
        if (isEnemy)
        {
            projectileHolder = GameObject.FindWithTag(TagManager.PLAYER_PROJECTILE_HOLDER_TAG);
        }
        else
        {
            projectileHolder = GameObject.FindWithTag(TagManager.ENEMY_PROJECTILE_HOLDER_TAG);
        }
    }

    private void Update()
    {
        if (Time.time>shootTimer)
        {
            canShoot = true;
            
        }
        
        HandlePlayerShooting();
        
        HandleEnemyShooting();
    }

    private void HandlePlayerShooting()
    {
        if (!canShoot||isEnemy)
        {
            return;
        }

        if (Input.GetKeyDown(keyToPressToShoot))
        {
            GetObjectFromPoolOrSpawnNewOne();
            
            ResetShootingTimer();
        }
    }

    private void GetObjectFromPoolOrSpawnNewOne()
    {
        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                projectilePool[i].transform.position=projectileSpawnPoint.position;
                projectilePool[i].SetActive(true);

                projectileSpawned = true;
                
                break;
            }
            else
            {
                projectileSpawned = false;
            }
        }

        if (!projectileSpawned)
        {
            GameObject newProjectile = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
            
            projectilePool.Add(newProjectile);
            
            newProjectile.transform.SetParent(projectileHolder.transform);

            projectileSpawned = true;
        }
    }

    private void ResetShootingTimer()
    {
        canShoot = false;

        if (isEnemy)
        {
            shootTimer = Time.time + shootWaitTime+1f;
        }
        else
        {
            shootTimer = Time.time + shootWaitTime;
        }
    }

    private void HandleEnemyShooting()
    {
        
    }
}
