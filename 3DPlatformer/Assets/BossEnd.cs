using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.PLAYER_TAG))
        {
            print("Player");
            FightManager.instance.WinGame();
        }
    }
}
