using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 100f;

    [SerializeField] private GameObject coinFX;
    [SerializeField] private Transform coinFXSpawnPosition;

    private void Update()
    {
        transform.Rotate(0f,rotateSpeed*Time.deltaTime,0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.PLAYER_TAG))
        {
            Instantiate(coinFX, coinFXSpawnPosition.position, Quaternion.identity);
            UIManager.instance.AddCoin();
            AudioManager.instance.PlayCoinPick();
            Destroy(gameObject);
        }
    }
}
