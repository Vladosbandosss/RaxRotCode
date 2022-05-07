using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RotateSpinning : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 200f;

    private float zAngle;

    private void Start()
    {
        if (Random.Range(0, 2) > 0)
        {
            rotateSpeed *= -1f;
        }
    }

    private void Update()
    {
        zAngle += Time.deltaTime * rotateSpeed;
        transform.rotation=Quaternion.AngleAxis(zAngle,Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.PLAYERTAG))
        {
            Destroy(other.gameObject);
        }
    }
}
