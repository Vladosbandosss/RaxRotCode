using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [HideInInspector]
    public int heath = 3;

    private int maxHealth;

    public static PlayerHealth instance;

    private void Awake()
    {
       if (instance==null)
       {
          instance = this;
       }

       maxHealth = heath;
    }


    public void TakeDamage(int damage)
   {
      heath-=damage;
      GameManager.instance.DecreasePlayerLives();

      if (heath<=0)
      {
         GameManager.instance.PlayerDie();
         Destroy(gameObject);
      }
   }

    public void PickUpHealth()
    {
       heath++;
       if (heath>maxHealth)
       {
          heath = maxHealth;
       }
    }
}
