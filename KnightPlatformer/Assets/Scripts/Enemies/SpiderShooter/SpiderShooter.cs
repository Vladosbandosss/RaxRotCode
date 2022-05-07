using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpiderShooter : MonoBehaviour
{
   [SerializeField] private GameObject bullet;

   [SerializeField] private Transform bulletSpawnPoint;

   [SerializeField] private float minShootTime = 2f, maxShootTime = 5f;

   private float shootTimer;
   
   private void Start()
   {
      shootTimer = Time.time + Random.Range(minShootTime, maxShootTime);
   }

   private void Update()
   {
      if (Time.time > shootTimer)
      {
         ShootBullet();
         shootTimer = Time.time + Random.Range(minShootTime, maxShootTime);
      }
   }

   private void ShootBullet()
   {
      Instantiate(bullet, transform.position, Quaternion.identity);
   }
}
