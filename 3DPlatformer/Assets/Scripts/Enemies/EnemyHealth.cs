using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
     private int currentHealth;

     private int lifeTimeAfterDestroy = 3;

     [SerializeField] private Animator _animator;

     [SerializeField] private GameObject deadFX;
     [SerializeField] private Transform deadFXspawnPosition;

     [SerializeField] private GameObject skeletonCoin;
     [SerializeField] private Transform skeletonSpawnCoinPosition;


     private void Start()
     {
         currentHealth = maxHealth;
     }

     public void TakeDamage()
     {
         currentHealth--;
         
         if (currentHealth<=0)
         {
             Instantiate(skeletonCoin, skeletonSpawnCoinPosition.position, Quaternion.identity);
             Instantiate(deadFX, deadFXspawnPosition.position, Quaternion.identity);
             AudioManager.instance.PlayDead();
             _animator.Play(TagManager.SKELETON_DEAD_ANIMATION);
             Invoke("DestroySkeleton",lifeTimeAfterDestroy);
         }
     }

     private void DestroySkeleton()
     {
         Destroy(gameObject);
     }
}
