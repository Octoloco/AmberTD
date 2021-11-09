using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowersPanel : UIPanel
{
    [SerializeField]
    private Button[] buttons;

    public void AddBuyEvents(TowerPlaceScript TPSReference)
    {
        buttons[0].onClick.AddListener(() => TPSReference.BuyTower(1));
        buttons[1].onClick.AddListener(() => TPSReference.BuyTower(2));
        buttons[2].onClick.AddListener(() => TPSReference.BuyTower(3));
    }

    public void RemoveBuyEvents()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.RemoveAllListeners();
        }
    }
}
