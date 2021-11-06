using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceScript : MonoBehaviour
{
    [SerializeField]
    private ObjectPool poolTower1;
    [SerializeField]
    private ObjectPool poolTower2;
    [SerializeField]
    private ObjectPool poolTower3;

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
            GameObject newTower = poolTower1.GetObjectFromPool();
            newTower.GetComponent<TowerScript>().Initialize(transform.position);
        }
        else if (type == 2)
        {
            GameObject newTower = poolTower2.GetObjectFromPool();
            newTower.GetComponent<TowerScript>().Initialize(transform.position);
        }
        else if (type == 3)
        {
            GameObject newTower = poolTower3.GetObjectFromPool();
            newTower.GetComponent<TowerScript>().Initialize(transform.position);
        }
    }
}
