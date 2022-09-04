 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerTarget;

    [SerializeField] private float moveSpeed = 2f;

    private Vector3 tempScale;

    [SerializeField] private float stopDistance = 1.5f;

    private PlayerAnimation enemyAnimation;

    [SerializeField] private float attackWaitTime = 2f;
    private float atackTimer;

    [SerializeField] private float attackFinishedWaitTime = 0.5f;
    private float attackFinishedTimer;

    [SerializeField] private GameObject damagePlayerArea;

    private bool enemyDied;

    private float destroyEnemyTimer = 1.5f;

    private void Awake()
    {
        playerTarget = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
        
        enemyAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if (enemyDied)
        {
            return;
        }
        
        SearchForPlayer();
    }

    private void SearchForPlayer()
    {
        if (!playerTarget)
        {
            return;
        }

        if (Vector3.Distance(transform.position,playerTarget.position)>stopDistance)
        {
            transform.position = Vector2.MoveTowards
                (transform.position, playerTarget.position, moveSpeed * Time.deltaTime);
            
            enemyAnimation.PlayAnimation(TagManager.WALK_ANIMATION_NAME);
            
            HandleFacingDirection();
        }
        else
        {
            CheckIfAttackFinished();
            
            Attack();
        }
    }

    private void HandleFacingDirection()
    {
        tempScale = transform.localScale;
        if (transform.position.x>playerTarget.position.x)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }

        transform.localScale = tempScale;
    }

    private void CheckIfAttackFinished()
    {
        if (Time.time>attackFinishedTimer)
        {
            enemyAnimation.PlayAnimation(TagManager.IDLE_ANIMATION_NAME);
        }
    }

    private void Attack()
    {
        if (Time.time>atackTimer)
        {
            attackFinishedTimer = Time.time + attackFinishedWaitTime;
            atackTimer = Time.time + attackWaitTime;
            
            enemyAnimation.PlayAnimation(TagManager.ATTACK_ANIMATION_NAME);
        }
    }

    private void ActivateDamageArea()
    {
        damagePlayerArea.SetActive(true);
    }

    private void DeactivateDamageArea()
    {
        damagePlayerArea.SetActive(false);
    }

    public void EnemyDied()
    {
        enemyDied = true;
        enemyAnimation.PlayAnimation(TagManager.DEATH_ANIMATION_NAME);
        Invoke("DestroyEnemy",destroyEnemyTimer);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
