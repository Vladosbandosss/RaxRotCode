using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    public static GamePlayUIController instance;

    [SerializeField] private Text waveInfoText, shipDestroyedInfoTxt, meteorsDestroyedTxt;
    private int waveCount, shipsDestroyedCount, meteorsDestroyedCount;
    
    
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    
    public int GetShipDestroyedCount()
    {
        return shipsDestroyedCount;
    }

    public int GetMeteorsDestroyedCount()
    {
        return meteorsDestroyedCount;
    }

    public int GetWaveCount()
    {
        return waveCount;
    }

    public void SetInfo(int infoType)
    {
        switch (infoType)
        {
            case 1:
                waveCount++;
                waveInfoText.text = "Wave:" + waveCount;
                break;
            case 2:
                shipsDestroyedCount++;
                shipDestroyedInfoTxt.text = shipsDestroyedCount + "x";
                break;
            case 3:
                meteorsDestroyedCount++;
                meteorsDestroyedTxt.text = meteorsDestroyedCount + "x";
                break;
        }
    }
    
    
}
