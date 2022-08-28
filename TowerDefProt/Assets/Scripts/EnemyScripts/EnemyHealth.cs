using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 15f;
    
    [SerializeField] private Slider enemyHealthSlider;

    [SerializeField] private int moneyOnDead = 50;

    private void Awake()
    {
        enemyHealthSlider.maxValue = health;
        enemyHealthSlider.value = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        enemyHealthSlider.value = health;

        if (health<=0)
        {
            Money.instance.GiveMoney(moneyOnDead);
            Destroy(gameObject);
        }
    }
}
