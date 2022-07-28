using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLifeTimer : MonoBehaviour
{
    [SerializeField] private float lifeTimer = 5f;

    private void Start()
    {
        Destroy(gameObject,lifeTimer);
    }
}
