using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    [SerializeField] private int maxHealth=5;
    private int currentHealth;

    private bool isPlayerEnable;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
    }

    public void DamagePlayer()
    {
        currentHealth--;
        
        UIController.instance.healthSlider.value = currentHealth;
        AudioManager.instance.PlayPlayerHurtMusic();
        StartCoroutine("ShowInvins");

        if (currentHealth<=0)
        {
            PlayerController.instance.gameObject.SetActive(false);
            UIController.instance.ShowDeadScreen();
            AudioManager.instance.PlayGameOverMusic();
        }
    }

    private IEnumerator ShowInvins()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerController.instance.gameObject.SetActive(isPlayerEnable);
            isPlayerEnable = !isPlayerEnable;
            yield return new WaitForSeconds(0.05f);
        }

        PlayerController.instance.gameObject.SetActive(true);
    }

    public void HealPlayer()
    {
        currentHealth++;
        if (currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        UIController.instance.healthSlider.value = currentHealth;
    }
}
