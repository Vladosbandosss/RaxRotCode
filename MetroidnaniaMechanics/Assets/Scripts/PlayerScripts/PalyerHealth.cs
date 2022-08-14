using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth, maxHealth;
    
    private SpriteRenderer sr;
    private bool eneblePlayer = true;

    [SerializeField] private GameObject playerDeadFX;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        
        UIController.instance.UpdateHealth(currentHealth,maxHealth);
        
    }

    public void DamagePlayer(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth<=0)
        {
            //GO PANEL
            Instantiate(playerDeadFX, transform.position, transform.rotation);
            Destroy(gameObject);  
        }
        
        UIController.instance.UpdateHealth(currentHealth,maxHealth);

        StartCoroutine("ShowInvinsDamage");

    }

    private IEnumerator ShowInvinsDamage()
    {
        for (int i = 0; i < 10; i++)
        {
            eneblePlayer = !eneblePlayer;
            sr.enabled = eneblePlayer;
            yield return new WaitForSeconds(0.05f);
        }
        sr.enabled = true;
    }

    public void HealPlayer(int healAmmount)
    {
        currentHealth += healAmmount;

        if (currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        UIController.instance.UpdateHealth(currentHealth,maxHealth);
    }
}
