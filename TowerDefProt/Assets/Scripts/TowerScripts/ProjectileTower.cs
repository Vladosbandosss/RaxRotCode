using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    [SerializeField] private Transform luncherModel;
    private Tower _tower;

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float timeBetweenShoots=1f;
    private float shootCounter;

    

    private Transform target;

    private void Awake()
    {
        _tower = GetComponent<Tower>();
    }

    private void Update()
    {
        if (target!=null)
        {
            luncherModel.LookAt(target);
        }
        
        if (_tower.enemiesInRange.Count>0)
        {
            float minDistance = _tower.range + 1f;

            foreach (var enemy in _tower.enemiesInRange)
            {
                if (enemy!=null)
                {
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distance<minDistance)
                    {
                        minDistance = distance;
                        target = enemy.transform;
                    }
                }
            }
        }
        else
        {
            target = null;
        }
        
        if (Time.time>shootCounter&&target!=null)
        {
            firePoint.LookAt(target);
            
            Shoot();
            shootCounter = Time.time + timeBetweenShoots;
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
}
