using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum CollectableType
{
    Health,
    Blaster1,
    Blaster2,
    Rocket,
    Missile
}
public class Collectables : MonoBehaviour
{
    
    public CollectableType type;

    [SerializeField] private float moveSpeed = 5f;

    private Vector3 tempPos;

    [HideInInspector] public float healthValue;

    private float minHealth = 10f, maxHealth = 30f;

    private void Start()
    {
        healthValue = Random.Range(minHealth, maxHealth);
    }
    
    
    private void Update()
    {
        tempPos = transform.position;
        tempPos.y -= moveSpeed * Time.deltaTime;

        transform.position = tempPos;
    }
    
}
