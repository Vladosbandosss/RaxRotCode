using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource levelMusic, gameOverMusic, winMusic;

    [SerializeField] private AudioSource healthPickUp, boxDestroy, playerShoot, playerHurt;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        levelMusic.Play();
    }

    public void PlayGameOverMusic()
    {
        levelMusic.Stop();
        gameOverMusic.Play();
    }

    public void PlayLevelWinMusic()
    {
        levelMusic.Stop();
        winMusic.Play();
    }

    public void PlayHealthPickUpMusic()
    {
        healthPickUp.Play();
    }

    public void PlayBoxDestroyMusic()
    {
        boxDestroy.Play();
    }

    public void PlayPlayerShootMusic()
    {
        playerShoot.Play();
    }

    public void PlayPlayerHurtMusic()
    {
        playerHurt.Play();
    }
}
