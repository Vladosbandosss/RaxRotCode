using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [SerializeField] private float totalHealth=100f;
    [HideInInspector]public float currentHealth;

    [SerializeField] private Slider healthSlider;

    public Transform[] attackPoints;

    private void Start()
    {
        currentHealth = totalHealth;
        healthSlider.maxValue = totalHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(float takeDamage)
    {
        currentHealth -= takeDamage;
        healthSlider.value = currentHealth;

        if (currentHealth<=0)
        {
            gameObject.SetActive(false);
            print("Game Over");
            LevelManager.instance.GameOver();
        }
        
        
    }
}
