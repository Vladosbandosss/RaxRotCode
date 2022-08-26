using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private string package = "Package";
    private string customer = "Customer";
    private string stop = "Stop";

    //[SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    //[SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    private SpriteRenderer _sr;
    private PlayerController _playerController;

    private bool hasPackage;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        //_sr.color = noPackageColor;

        _playerController = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Oh");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(package)&&!hasPackage)
        {
            print("box");
            hasPackage = true;
            //_sr.color = hasPackageColor;
            Destroy(col.gameObject);
        }

        if (col.CompareTag(stop))
        {
            _playerController.MoveSpeed = 10f;
        }

        if (col.CompareTag(customer)&&hasPackage)
        {
            hasPackage = false;
           // _sr.color = noPackageColor;
            print("package delivered");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(stop))
        {
            _playerController.MoveSpeed = 15f;
        }
    }
}
