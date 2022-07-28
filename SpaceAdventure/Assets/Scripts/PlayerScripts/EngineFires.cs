using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineFires : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] engineFires;

    [SerializeField] private int enginePower = 3;

    private void Update()
    {
        HandleFireEngineEmit();
    }

    private void HandleFireEngineEmit()
    {
        if (Input.GetKey(KeyCode.W))
        {
            EminEngineFireParticle(2,enginePower);
            EminEngineFireParticle(3,enginePower);
        }
        if (Input.GetKey(KeyCode.S))
        {
            EminEngineFireParticle(4,enginePower);
            EminEngineFireParticle(5,enginePower);
        }
        if (Input.GetKey(KeyCode.A))
        {
            EminEngineFireParticle(0,enginePower);
        }
        if (Input.GetKey(KeyCode.D))
        {
            EminEngineFireParticle(1,enginePower);
        }
    }

    private void EminEngineFireParticle(int engineIndex, int enginePower)
    {
        engineFires[engineIndex].Emit(enginePower);
    }
}
