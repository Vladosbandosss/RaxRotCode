using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 50f;

    private void Update()
    {
        transform.Rotate(rotateSpeed*Time.deltaTime,0f,0f);
    }
}
