using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceScript : MonoBehaviour
{
    [SerializeField]
    private CurrencyScriptableObject currencyData;
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
    private bool canClick = true;
    public GameObject currentTower;

    private void OnMouseDown()
    {
        if (canClick)
        {
            if (!hasTower)
            {
                if (EconomyScript.instance.CanAfford(currencyData.Tower1Cost))
                {
                    WorldCanvasManager.instance.ShowTowersPanel(this);
                }
            }
            else
            {
                WorldCanvasManager.instance.ShowTowersPanel2(this);
            }
        }
        canClick = false;
        StartCoroutine(ClickCooldown());
    }

    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.Mouse0) && canClick)
        {
            if (WorldCanvasManager.instance.IsTowersPanelOpened())
            {
                StartCoroutine(ClickCooldown());
                canClick = false;
                WorldCanvasManager.instance.HideTowersPanel();
                WorldCanvasManager.instance.HideTowersPanel2();
            }
        }
    }

    public void RemoveTower()
    {
        hasTower = false;
    }

    public void BuyTower(int type)
    {
        if (!hasTower)
        {
            if (type == 1)
            {
                if (EconomyScript.instance.CanAfford(currencyData.Tower1Cost))
                {
                    hasTower = true;
                    currentTower = poolTower1.GetObjectFromPool();
                    currentTower.GetComponent<TowerScript>().Initialize(transform.position, ammoPool1);
                    EconomyScript.instance.ReduceCurrency(currencyData.Tower1Cost);
                }
            }
            else if (type == 2)
            {
                if (EconomyScript.instance.CanAfford(currencyData.Tower2Cost))
                {
                    hasTower = true;
                    currentTower = poolTower2.GetObjectFromPool();
                    currentTower.GetComponent<TowerScript>().Initialize(transform.position, ammoPool2);
                    EconomyScript.instance.ReduceCurrency(currencyData.Tower2Cost);
                }
            }
            else if (type == 3)
            {
                if (EconomyScript.instance.CanAfford(currencyData.Tower3Cost))
                {
                    hasTower = true;
                    currentTower = poolTower3.GetObjectFromPool();
                    currentTower.GetComponent<TowerScript>().Initialize(transform.position, ammoPool3);
                    EconomyScript.instance.ReduceCurrency(currencyData.Tower3Cost);
                }
            }
        }
    }

    IEnumerator ClickCooldown()
    {
        yield return new WaitForSeconds(.2f);
        canClick = true;
    }
}
