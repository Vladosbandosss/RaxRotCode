using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] projectiles;

    [SerializeField] private Transform[] projectileSpawnPoints;

    [SerializeField] private float shootTimerTreshHold = 0.2f;

    private float shootTimer;

    private bool canShoot;

    private void Update()
    {
        if (Time.time>shootTimer)
        {
            canShoot = true;
        }
        
        HandlePlayerShooting();
    }

    private void HandlePlayerShooting()
    {
        if (!canShoot)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(projectiles[0],projectileSpawnPoints[0].position,Quaternion.identity);
            
            Instantiate(projectiles[0],projectileSpawnPoints[1].position,Quaternion.identity);
            
            ResetShootingTimer();
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(projectiles[1],projectileSpawnPoints[0].position,Quaternion.identity);
            
            Instantiate(projectiles[1],projectileSpawnPoints[1].position,Quaternion.identity);
            
            ResetShootingTimer();
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(projectiles[2],projectileSpawnPoints[0].position,Quaternion.identity);
            
            Instantiate(projectiles[2],projectileSpawnPoints[1].position,Quaternion.identity);
            
            ResetShootingTimer();
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            Instantiate(projectiles[3],projectileSpawnPoints[2].position,Quaternion.identity);
            
            ResetShootingTimer();
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(projectiles[4],projectileSpawnPoints[2].position,Quaternion.identity);
            
            ResetShootingTimer();
        }
    }

    private void ResetShootingTimer()
    {
        canShoot = false;
        
        shootTimer = Time.time + shootTimerTreshHold;
    }
}
