using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveAxis, rotateAxis;

    [SerializeField] private float steerSpeed = 150f;
    [SerializeField] private float moveSpeed = 15f;

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rotateAxis = Input.GetAxisRaw("Horizontal")*steerSpeed*Time.deltaTime;
        moveAxis = Input.GetAxisRaw("Vertical")*moveSpeed*Time.deltaTime;

        // if (moveAxis<0)
        // {
        //     steerSpeed *= -1f;
        // }
        // else
        // {
        //     steerSpeed = Mathf.Abs(steerSpeed);
        // }
        
        transform.Rotate(0,0,-rotateAxis);
        transform.Translate(0,moveAxis,0f);
    }
}
