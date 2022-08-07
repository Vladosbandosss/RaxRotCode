using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RotateObstacle : MonoBehaviour
{
    [SerializeField] private float minRotateSpeed = 250f,maxRotateSpeed=400f;
    private float rotateSpeed;
    
    private float zAngle;

    private void Start()
    {
        rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);

        if (Random.Range(0,2)>0)
        {
            rotateSpeed *= -1f;
        }
    }

    private void Update()
    {
        zAngle += Time.deltaTime * rotateSpeed;
        transform.rotation=Quaternion.AngleAxis(zAngle,Vector3.forward);
    }
}
