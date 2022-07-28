using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    private float yAxis;

    private Material bgMaterial;

    private void Awake()
    {
        bgMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        yAxis += speed * Time.deltaTime;
        
        bgMaterial.SetTextureOffset("_MainTex",new Vector2(0f,yAxis));
    }
}
