using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
     public float range = 3f;
    [SerializeField] private LayerMask whatIsEnemy;
    public Collider[] collidersInRange;

    public List<EnemyController> enemiesInRange = new List<EnemyController>();

    private float checkCounter;
    [SerializeField]private float checkTime = 0.5f;

    public GameObject rangeModel;

    public int cost = 100;

    private void Update()
    {
        if (Time.time>checkCounter)
        {
            print("check");
            CheckEnemies();
            checkCounter = Time.time + checkTime;
        }
    }

    private void CheckEnemies()
    {
        collidersInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);
        
        enemiesInRange.Clear();

        foreach (var col in collidersInRange)
        {
            enemiesInRange.Add(col.GetComponent<EnemyController>());
        }
    }
}
