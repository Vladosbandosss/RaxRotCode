using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EenemyFXLifeTimer : MonoBehaviour
{
   [SerializeField] private float timer = 3f;

   private void Start()
   {
      Destroy(gameObject,timer);
   }
}
