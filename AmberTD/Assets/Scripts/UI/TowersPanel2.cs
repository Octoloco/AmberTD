using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowersPanel2 : UIPanel
{
    [SerializeField]
    private Button[] buttons;

    public void AddEvents(TowerPlaceScript TPSReference)
    {
        buttons[0].onClick.AddListener(() => TPSReference.currentTower.GetComponent<TowerScript>().Die());
        buttons[0].onClick.AddListener(() => EconomyScript.instance.AddCurrency(5));
        buttons[0].onClick.AddListener(() => TPSReference.RemoveTower());
        buttons[1].onClick.AddListener(() => TPSReference.currentTower.GetComponent<TowerScript>().Upgrade());
    }

    public void RemoveEvents()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.RemoveAllListeners();
        }
    }
}
