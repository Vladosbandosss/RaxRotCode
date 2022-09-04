using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScripts : MonoBehaviour
{
    [SerializeField] private float health=100f;

    [SerializeField] private Slider healthSlider;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void TakeDamage(float damageAmount)
    {
        if (health<=0)
        {
            return;
        }
        
        health -= damageAmount;
        healthSlider.value = health;

        if (health<=0)
        {
            health = 0;
           _enemy.EnemyDied();
           
           EnemySpawner.instance.EnemyDied(gameObject);
           
           GameplayController.instance.EnemyKilled();
        }
    }
}
