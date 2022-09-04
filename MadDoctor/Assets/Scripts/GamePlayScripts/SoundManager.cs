using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioClip shootSound;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    public void PlayShootMusic()
    {
        AudioSource.PlayClipAtPoint(shootSound,transform.position);
    }
}
