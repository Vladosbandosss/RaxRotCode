using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;
    
    [SerializeField] private Tower activeTower;

    [SerializeField] private Transform indicator;
    public bool isPlacing;

    [SerializeField] private LayerMask whatIsPlacement;

    [SerializeField] private float topSafePercent = 15f;
    
    

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (isPlacing)
        {
            indicator.position = GetGridPosition();

            if (Input.GetMouseButtonDown(0)&&Money.instance.SpendMoney(activeTower.cost))
            {
                Instantiate(activeTower, indicator.position, activeTower.transform.rotation);
                indicator.gameObject.SetActive(false);
                activeTower.rangeModel.SetActive(false);
            }
            
            
        }
    }

    public void StartTowerPlacement(Tower towerToPlace)
    {
        activeTower = towerToPlace;
        isPlacing = true;
        
       Destroy(indicator.gameObject);
       Tower placeTower = Instantiate(activeTower);
       placeTower.enabled = false;
       indicator = placeTower.transform;
       
       placeTower.rangeModel.SetActive(true);
       placeTower.rangeModel.transform.localScale = new Vector3(placeTower.range, 1f, placeTower.range);
    }

    public Vector3 GetGridPosition()
    {
        Vector3 location = new Vector3(2f,0f,2f);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Input.mousePosition.y>Screen.height*(1-topSafePercent/100f))
        {
            indicator.gameObject.SetActive(false);
        }
        else
        {
            indicator.gameObject.SetActive(true);
        }

         if (Physics.Raycast(ray,out hit,200f,whatIsPlacement))
        {
            location = hit.point;
        }

        location.y = 0f;

        return location;
    }
}
