using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public TMP_Text goldText;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
}