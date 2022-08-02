using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 200f;

    private float zAngle;

    private void Update()
    {
        zAngle += Time.deltaTime * rotateSpeed;
        transform.rotation=Quaternion.AngleAxis(zAngle,Vector3.forward);
    }
}
