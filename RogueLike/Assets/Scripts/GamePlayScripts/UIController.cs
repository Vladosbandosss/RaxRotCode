using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider healthSlider;

    public static UIController instance;

    [SerializeField] private GameObject deadScreen;

    [SerializeField] private GameObject fade;

    public Image fadeScreen;
    [SerializeField] private float fadeSpeed;
    private bool fadeToBlack, fadeOutBlack;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        
    }

    private void Start()
    {
        fadeOutBlack = true;
        fadeToBlack = false;
    }

    private void Update()
    {
        if (fadeOutBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 0, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a==0)
            {
                fadeOutBlack = false;
            }
        }
        
        if (fadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 1, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a==1f)
            {
                fadeToBlack = false;
            }
        }
        
    }

    public void StartFadeToBlack()
    {
        fadeToBlack = true;
        fadeOutBlack = false;
    }
    
    public void ShowDeadScreen()
    {
        fade.SetActive(false);
        deadScreen.SetActive(true);
    }
}
