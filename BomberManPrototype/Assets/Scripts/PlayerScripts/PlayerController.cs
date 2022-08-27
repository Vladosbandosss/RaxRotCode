using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    
    private Vector3 movePosition;

    [SerializeField] private GameObject bombToSpawn;
    private GameObject bomb;

    private GameManager myGameManager;

    [SerializeField] private int maxBombs = 3;
    private int currentBombPlaced = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        myGameManager = FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        MovePlayer();
        
        PlantBomb();
    }

    private void MovePlayer()
    {
        movePosition.x = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS) * moveSpeed;
        movePosition.z = Input.GetAxisRaw(TagManager.VERTICAL_AXIS) * moveSpeed;
        //movePosition = movePosition.normalized;

        rb.velocity = new Vector3(movePosition.x,movePosition.y,movePosition.z);
    }

    private void PlantBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&currentBombPlaced<maxBombs)
        {
           bomb = Instantiate(bombToSpawn, transform.position, Quaternion.identity);
           bomb.transform.position =
               new Vector3(Mathf.Round(transform.position.x), 0f, Mathf.Round(transform.position.z));
           currentBombPlaced++;
        }
    }

    public void BombExploded()
    {
        currentBombPlaced--;
    }
}
