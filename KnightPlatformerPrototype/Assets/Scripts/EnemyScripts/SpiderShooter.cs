using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField]private Transform bulletSpawnPoint;

    [SerializeField] private float minShootTime = 2f, maxShootTime = 5f;

    private void Start()
    {
        StartCoroutine("Shoot");
    }

    private void ShootBullet()
    {
        Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(minShootTime, maxShootTime));
        ShootBullet();

        StartCoroutine("Shoot");
    }
}
