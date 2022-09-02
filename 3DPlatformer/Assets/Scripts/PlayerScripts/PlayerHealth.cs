using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    
    public int currentHealth, maxHealth = 5;

    private bool setActive;
    public GameObject playerPartToInvins;

    [SerializeField] private GameObject playerDeadFX;
    
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
        UIManager.instance.UpdateLives();
    }

    public void HurtPlayer()
    {
        currentHealth--;
        UIManager.instance.UpdateLives();
        StartCoroutine("MakeHurtInvins");
        AudioManager.instance.PlayPlayerHurt();
        if (currentHealth<=0)
        {
            print("POMER");
            Instantiate(playerDeadFX, transform.position, Quaternion.identity);
            GameManager.instance.Respawn();
            AudioManager.instance.PlayDead();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UIManager.instance.UpdateLives();
    }

    private IEnumerator MakeHurtInvins()
    {
        for (int i = 0; i < 10; i++)
        {
            playerPartToInvins.SetActive(setActive);
            yield return new WaitForSeconds(0.2f);
            setActive = !setActive;
        }
        playerPartToInvins.SetActive(true);
    }

    public void HealPlayer()
    {
        currentHealth++;

        if (currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIManager.instance.UpdateLives();
        AudioManager.instance.PlayHealPlayer();
    }
}
