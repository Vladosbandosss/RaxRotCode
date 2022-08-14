using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlayer : MonoBehaviour
{
    [SerializeField] private float rangeToChase;
    private bool isChasing;

    [SerializeField] private float moveSpeed, turnSpeed;

    private Transform player;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void Update()
    {

        if (!player)
        {
            return;
        }
        
        if (!isChasing)
        {
            if (Vector3.Distance(transform.position,player.position)<rangeToChase)
            {
                isChasing = true;
            }
        }
        else
        {
            Vector3 direction = transform.position - player.position;
            float angle = MathF.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRot=Quaternion.AngleAxis(angle,Vector3.forward);
            
            transform.rotation=Quaternion.Slerp(transform.rotation,targetRot,turnSpeed*Time.deltaTime);
            
            transform.position=Vector3.MoveTowards(transform.position,player.position,moveSpeed*Time.deltaTime);

            //transform.position += -transform.right * moveSpeed * Time.deltaTime;
            
            //transform.LookAt(player);
        } 
        
        _anim.SetBool(TagManager.FLAYER_CHASING_PARAMETR,isChasing);
    }
    
    
    
    
}
