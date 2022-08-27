using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private PlayerController _playerController;
    private SphereCollider _sphereCollider;

    [SerializeField] private float explodeDelay = 3f;

    [SerializeField] private GameObject explode;
    [SerializeField] private float explodeSpeed = 200f;
    [SerializeField] private float explodeRange = 2f;
    

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _playerController = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).GetComponent<PlayerController>();
    }

    private void Start()
    {
        Invoke("Explode",explodeDelay);
    }

    public void Explode()
    {
        GameObject explossionRight = Instantiate(explode,transform.position, Quaternion.identity);
        explossionRight.GetComponent<Explossion>().SetExplossion(Vector3.right,explodeSpeed,explodeRange);
        
        GameObject explossionLeft = Instantiate(explode,transform.position, Quaternion.identity);
        explossionLeft.GetComponent<Explossion>().SetExplossion(Vector3.left,explodeSpeed,explodeRange);
        
        GameObject explossionForward = Instantiate(explode,transform.position, Quaternion.identity);
        explossionForward.GetComponent<Explossion>().SetExplossion(Vector3.forward,explodeSpeed,explodeRange);
        
        GameObject explossionBack = Instantiate(explode,transform.position, Quaternion.identity);
        explossionBack.GetComponent<Explossion>().SetExplossion(Vector3.back,explodeSpeed,explodeRange);
        
        _playerController.BombExploded();
        
        Destroy(gameObject);
    }

    private void Update()
    {
        // if (Time.time>explodeDelay)
        // {
        //     print("boom");
        //     Destroy(gameObject);
        // }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagManager.PLAYER_TAG))
        {
            _sphereCollider.isTrigger = false;
        }
    }
    
}
