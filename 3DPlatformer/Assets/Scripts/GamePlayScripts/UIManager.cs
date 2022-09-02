using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField] private Image blackScreen;
    [SerializeField] private float fadeSpeed = 2f;
    [HideInInspector]public bool fadeToBlack, fadeFromBlack;

    [SerializeField] private GameObject[] imageLives;
    [SerializeField] private Text liveText;
    private int textLIves;
    
    private int currentCoins;
    [SerializeField] private Text coinText;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }

        currentCoins = 0;
        coinText.text = currentCoins.ToString();
    }
    
    private void Update()
    {
        if (fadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
                Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }

        if (fadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
                Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
        
    }

    public void UpdateLives()
    {
        for (int i = 0; i < imageLives.Length; i++)
        {
            if (PlayerHealth.instance.currentHealth==i+1)
            {
                imageLives[i].SetActive(true);
                textLIves = i + 1;
                liveText.text = textLIves.ToString();
            }
            else
            {
                imageLives[i].SetActive(false);
            }
        }
    }

    public void AddCoin()
    {
        currentCoins++;
        coinText.text = currentCoins.ToString();
    }
}
