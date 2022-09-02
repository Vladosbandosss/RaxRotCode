using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] private Transform[] patrolPoints;
    private int currentPatrolPoint;

    [SerializeField] private float chaseRange = 5f;
    private float distanceToPlayer;
    private Transform target;

    [SerializeField] private float attackRange = 1f;

    [SerializeField] private Animator _animator;

    private enum AIState
    {
        isPatroling,
        isChasing,
        isAttacking
    };
    private AIState currentState;
    

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        currentState = AIState.isPatroling;
        
        target=GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void Update()
    {
        Movement();
        
    }

    private void Movement()
    {
        distanceToPlayer = Vector3.Distance(transform.position, target.position);
        
        switch (currentState)
        {
            case AIState.isPatroling:
                
                Patrol();
                
                break;
            
            case AIState.isChasing:
                
                Chasing();
                
                break;
            
            case AIState.isAttacking:
                
                Attack();
                
                break;
        }
    }

    private void Patrol()
    {
        if (distanceToPlayer<=chaseRange)
        {
            currentState = AIState.isChasing;
        }
        
        if (_agent.remainingDistance<=0.2f)
        {
            currentPatrolPoint++;
        }

        if (currentPatrolPoint>=patrolPoints.Length)
        {
            currentPatrolPoint = 0;
        }
        
        _agent.SetDestination(patrolPoints[currentPatrolPoint].position);
        _animator.SetBool(TagManager.SKELETON_RUN_ANIMATION_PARAMETR,true);
        
    }

    private void Chasing()
    {
        if (distanceToPlayer>=chaseRange)
        {
            currentState = AIState.isPatroling;
        }
        
        _agent.SetDestination(target.position);
        _animator.SetBool(TagManager.SKELETON_RUN_ANIMATION_PARAMETR,true);

        if (distanceToPlayer<=attackRange)
        {
            print("Enter attack");
            currentState = AIState.isAttacking;
        }
    }

    private void Attack()
    {
        _animator.SetTrigger(TagManager.SKELETON_ATTACK_PARAMETR);
       transform.LookAt(target.position,Vector3.up);
        _agent.velocity=Vector3.zero;
        _agent.isStopped = true;

        if (distanceToPlayer>=attackRange)
        {
            currentState = AIState.isChasing;
            _agent.isStopped = false;
        }
    }
}
