using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioClip pickUpSound1, pickUpSound2;
    [SerializeField] private AudioClip destroySound1, destroySound2;
    [SerializeField] private AudioClip damageSound1, damageSound2;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    public void PlayPickUpSound()
    {
        if (Random.Range(0,2)>0)
        {
            AudioSource.PlayClipAtPoint(pickUpSound1,transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(pickUpSound2,transform.position);
        }
    }
    
    public void PlayDestroySound()
    {
        if (Random.Range(0,2)>0)
        {
            AudioSource.PlayClipAtPoint(destroySound1,transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(destroySound2,transform.position);
        }
    }
    
    public void PlayDamageSound()
    {
        if (Random.Range(0,2)>0)
        {
            AudioSource.PlayClipAtPoint(damageSound1,transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(damageSound2,transform.position);
        }
    }
}
