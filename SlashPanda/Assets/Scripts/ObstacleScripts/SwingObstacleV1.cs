using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingObstacleV1 : MonoBehaviour
{
    [SerializeField] private float minRotateSpeed = 250f,maxRotateSpeed=400f;
    private float rotateSpeed;
    
    private float zAngle;

    [SerializeField] private float minZRotation=-0.6f, maxZRotation=0.6f;

    private Rigidbody2D _rb;

    private bool rotateLeft;

    private void Awake()
    {
        rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);

        if (Random.Range(0,2)>0)
        {
            rotateSpeed *= -1f;
        }

        _rb = GetComponent<Rigidbody2D>();
        
        if (Random.Range(0,2)>0)
        {
            rotateLeft = true;
        }
    }

    private void Update()
    {
        //TransFormRotate();
        
        TransFromRB();
    }

    private void TransFormRotate()
    {
        zAngle += Time.deltaTime * rotateSpeed;
        transform.rotation=Quaternion.AngleAxis(zAngle,Vector3.forward);

        if (transform.rotation.z<minZRotation)
        {
            rotateSpeed=Mathf.Abs(rotateSpeed);
        }
        
        if (transform.rotation.z>maxZRotation)
        {
            rotateSpeed=-Mathf.Abs(rotateSpeed);
        }
    }

    private void TransFromRB()
    {
        if (transform.rotation.z>maxZRotation)
        {
            rotateLeft = true;
        }
        if (transform.rotation.z<minZRotation)
        {
            rotateLeft = false;
        }

        if (rotateLeft)
        {
            _rb.angularVelocity = -rotateSpeed;
        }
        else
        {
            _rb.angularVelocity = rotateSpeed;
        }
        
    }
}
