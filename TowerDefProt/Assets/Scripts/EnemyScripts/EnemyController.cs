using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Transform target;

    private Path _path;
    private Castle _castle;
    private int currentPoint;
    private float checkDistanceToChange = 0.01f;
    private bool reachedEnd;

    [SerializeField]private float timeBetweenAttacks = 2f;
    private float attackCounter;
    [SerializeField] private float damagePerAttack = 5f;

    private int selectedAttackPoint;
    
    private void Awake()
    {
        if (_path==null)
        {
            _path = FindObjectOfType<Path>();
        }

        if (_castle==null)
        {
            _castle = FindObjectOfType<Castle>();
        }
        selectedAttackPoint = Random.Range(0, _castle.attackPoints.Length);
    }

    private void Update()
    {
        if (_castle.currentHealth<=0)
        {
            return;
        }
        if (!reachedEnd)
        {
            MoveToTarget();
        }
        else
        {
            Attack();
        }
    }

    private void MoveToTarget()
    {
        transform.LookAt(_path.points[currentPoint]);
        
        transform.position =
            Vector3.MoveTowards(transform.position, _path.points[currentPoint].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position,_path.points[currentPoint].position)<checkDistanceToChange)
        {
            currentPoint++;
            if (currentPoint>=_path.points.Length)
            {
                reachedEnd = true;
            }
        }
    }

    private void Attack()
    {
        print(selectedAttackPoint);
        transform.position = Vector3.MoveTowards
            (transform.position, _castle.attackPoints[selectedAttackPoint].position, speed * Time.deltaTime);;
        if (Time.time>attackCounter)
        {
            _castle.TakeDamage(damagePerAttack);
            attackCounter = Time.time + timeBetweenAttacks;
        }
    }

    public void SetUp(Castle newCastle, Path newPath)
    {
        _castle = newCastle;
        _path = newPath;
    }
}
