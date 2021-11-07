using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceScript : MonoBehaviour
{
    [Header("Tower Costs")]
    [SerializeField]
    private int tower1Price;
    [SerializeField]
    private int tower2Price;
    [SerializeField]
    private int tower3Price;
    [Header("Pools")]
    [SerializeField]
    private ObjectPool poolTower1;
    [SerializeField]
    private ObjectPool poolTower2;
    [SerializeField]
    private ObjectPool poolTower3;
    [SerializeField]
    private ObjectPool ammoPool1;
    [SerializeField]
    private ObjectPool ammoPool2;
    [SerializeField]
    private ObjectPool ammoPool3;

    private bool hasTower;

    private void OnMouseDown()
    {
        if (!hasTower)
        {
            WorldCanvasManager.instance.ShowTowersPanel(this);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (WorldCanvasManager.instance.IsTowersPanelOpened())
            {
                WorldCanvasManager.instance.HideTowersPanel();
            }
        }
    }

    public void BuyTower(int type)
    {
        hasTower = true;
        if (type == 1)
        {
            if (EconomyScript.instance.CanAfford(tower1Price))
            {
                GameObject newTower = poolTower1.GetObjectFromPool();
                newTower.GetComponent<TowerScript>().Initialize(transform.position, ammoPool1);
                EconomyScript.instance.ReduceCurrency(tower1Price);
            }
        }
        else if (type == 2)
        {
            if (EconomyScript.instance.CanAfford(tower2Price))
            {
                GameObject newTower = poolTower2.GetObjectFromPool();
                newTower.GetComponent<TowerScript>().Initialize(transform.position, ammoPool2);
                EconomyScript.instance.ReduceCurrency(tower1Price);
            }
        }
        else if (type == 3)
        {
            if (EconomyScript.instance.CanAfford(tower3Price))
            {
                GameObject newTower = poolTower3.GetObjectFromPool();
                newTower.GetComponent<TowerScript>().Initialize(transform.position, ammoPool3);
                EconomyScript.instance.ReduceCurrency(tower1Price);
            }
        }
    }
}
