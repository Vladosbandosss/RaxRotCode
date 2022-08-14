using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int totalHealth = 3;
    [SerializeField] private GameObject deadFX;

    public void DamageEnemy(int damageAmount)
    {
        totalHealth -= damageAmount;

        if (totalHealth<=0)
        {
            Instantiate(deadFX, transform.position, transform.rotation);
            Destroy(gameObject);
           
        }
    }
}
