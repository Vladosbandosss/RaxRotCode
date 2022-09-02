using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioSource levelClip, playerHurtClip, checkPointClip, playerHealClip, playerCoinClip, deadClip;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        
        levelClip.Play();
    }

    public void PlayPlayerHurt()
    {
        playerHurtClip.Play();
    }

    public void PlayCheckPoint()
    {
        checkPointClip.Play();
    }

    public void PlayHealPlayer()
    {
        playerHealClip.Play();
    }

    public void PlayCoinPick()
    {
        playerCoinClip.Play();
    }

    public void PlayDead()
    {
        deadClip.Play();
    }
}
