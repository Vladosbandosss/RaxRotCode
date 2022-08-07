using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBG : MonoBehaviour
{
    private GameObject[] backGrounds;

    [SerializeField] private string bgTag;

    private float highestXposition;

    private float offsetValue;

    private float newXpos;

    private Vector3 newPosition;

    private void Awake()
    {
        backGrounds = GameObject.FindGameObjectsWithTag(bgTag);

        offsetValue = backGrounds[0].GetComponent<BoxCollider2D>().bounds.size.x;

        highestXposition = backGrounds[0].transform.position.x;

        for (int i = 0; i < backGrounds.Length; i++)
        {
            if (backGrounds[i].transform.position.x>highestXposition)
            {
                highestXposition = backGrounds[i].transform.position.x;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(bgTag))
        {
            newXpos = highestXposition + offsetValue;
            highestXposition = newXpos;

            newPosition = col.transform.position;
            newPosition.x = newXpos;
            col.transform.position = newPosition;
        }
    }
}
